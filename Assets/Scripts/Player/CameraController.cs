using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Rotation")]
    [SerializeField] private float m_RotationSpeed;

    [SerializeField] private float m_MaxVerticalRotation;
    [SerializeField] private float m_MinVerticalRotation;

    [SerializeField] private bool m_InvertXRotation = false;
    [SerializeField] private bool m_InvertYRotation = false;

    [Header("Camera Zooming")]
    [Tooltip("Max zooming distance")]
    [SerializeField] private float m_MaxDistance;
    [Tooltip("Min zooming distance")]
    [SerializeField] private float m_MinDistance;

    [SerializeField] private float m_ZoomingSensibility;
    [SerializeField] private float m_MouseZoomingSensibility;

    private Camera m_Camera;

    private Vector2 m_StartPos;
    private Vector2 m_StartPos2;
    private Vector2 m_CurrentPos;
    private Vector2 m_CurrentPos2;

    private float m_CurrentScrollDelta = 0f;
    private float m_CameraZoomValue;

    private bool m_CanZoom = false;

    private float m_RotationY;
    private float m_RotationX;
    private Vector3 m_OriginalRotation;

    private int m_RotationDirectionX = 0;
    private int m_RotationDirectionY = 0;

    private void Start()
    {
        GameManager.instance.EventManager.Register(Constants.UPDATE_CAMERA_ROTATION, UpdateRotation);
        GameManager.instance.EventManager.Register(Constants.UPDATE_CAMERA_ZOOMING, UpdateZooming);
        GameManager.instance.EventManager.Register(Constants.STOP_CAMERA_ZOOMING, StopZooming);

        m_Camera = GetComponent<Camera>();
        CheckZoomingDistance();

        m_CurrentScrollDelta = m_Camera.fieldOfView;

        m_OriginalRotation = transform.eulerAngles;
        m_RotationY = m_OriginalRotation.y;

        if (m_InvertXRotation) m_RotationDirectionX = 1;
        else if (!m_InvertXRotation) m_RotationDirectionX = -1;
        if (m_InvertYRotation) m_RotationDirectionY = -1;
        else if (!m_InvertYRotation) m_RotationDirectionY = 1;
    }

    private void Update()
    {
        if (m_CanZoom)
        {
            Zooming();
        }
        else if (Input.mouseScrollDelta.y != 0f)
        {
            m_CurrentScrollDelta += Input.mouseScrollDelta.y;
            m_Camera.fieldOfView = m_CurrentScrollDelta * -1 * m_MouseZoomingSensibility;

            if (m_Camera.fieldOfView < m_MinDistance)
            {
                m_Camera.fieldOfView = m_MinDistance;
            }

            else if (m_Camera.fieldOfView > m_MaxDistance)
            {
                m_Camera.fieldOfView = m_MaxDistance;
            }
        }


    }

    #region Rotation

    /// <summary>
    /// update the rotation of the camera
    /// <summary>
    public void UpdateRotation(object[] param)
    {
        Vector2 delta = (Vector2)param[0];

        m_RotationY += delta.x * Time.deltaTime * m_RotationSpeed * m_RotationDirectionX;
        m_RotationX += delta.y * Time.deltaTime * m_RotationSpeed * m_RotationDirectionY;

        CheckVerticalBounds();

        transform.parent.rotation = Quaternion.Euler(0f, m_RotationY, 0f);
        transform.eulerAngles = new Vector3(m_RotationX, m_RotationY, 0f);
    }

    /// <summary>
    /// Check if the x rotation of the camera is in bounds and if it's not it sets it to the maximum rotation within the bounds
    /// </summary>
    private void CheckVerticalBounds()
    {
        if (m_RotationX > m_MaxVerticalRotation)
            m_RotationX = m_MaxVerticalRotation;
        else if (m_RotationX < m_MinVerticalRotation)
            m_RotationX = m_MinVerticalRotation;
    }

    #endregion

    //CHANGE ZOOMING FROM ORTOGRAPHICSIZE TO POSITION.Z
    #region Zooming

    /// <summary>
    /// Updates the parameters used by the zooming
    /// <summary>
    public void UpdateZooming(object[] param)
    {
        if (!m_CanZoom)
            m_CanZoom = true;

        m_StartPos = (Vector2)param[0];
        m_StartPos2 = (Vector2)param[1];
        m_CurrentPos = (Vector2)param[2];
        m_CurrentPos2 = (Vector2)param[3];
    }

    /// <summary>
    /// Stops the zooming
    /// <summary>
    public void StopZooming(object[] param)
    {
        CheckZoomingDistance();
        m_CanZoom = false;
    }

    /// <summary>
    /// Effective zoom
    /// <summary>
    private void Zooming()
    {
        float startDistance = Vector2.Distance(m_StartPos, m_StartPos2);
        float currentDistance = Vector2.Distance(m_CurrentPos, m_CurrentPos2);

        m_CameraZoomValue = ((currentDistance - startDistance) * m_ZoomingSensibility);
        m_Camera.fieldOfView -= m_CameraZoomValue;
        CheckZoomingDistance();
    }

    /// <summary>
    /// Chech if the zoom is in range and if it's not sets the zooming at a max or min (depending on the case)
    /// <summary>
    private void CheckZoomingDistance()
    {
        if (m_Camera.fieldOfView < m_MinDistance)
        {
            m_Camera.fieldOfView = m_MinDistance;
        }

        else if (m_Camera.fieldOfView > m_MaxDistance)
        {
            m_Camera.fieldOfView = m_MaxDistance;
        }
    }

    #endregion
}
