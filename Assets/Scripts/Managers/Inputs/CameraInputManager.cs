using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraInputManager : MonoBehaviour
{
    [SerializeField] private Transform m_Ball;
    [SerializeField] private Transform m_Camera;
    [SerializeField] private float m_LineMultiplier;

    private Vector3 m_TouchStartPosition;
    private Vector3 m_TouchEndPosition = Vector3.zero;
    private Vector2 m_TouchScreenStartPos;
    private Vector2 m_TouchScreenStartPos2;
    private Vector3 m_TouchTempPosition;

    [Header("Ranges")]
    [SerializeField] private float m_DeadZoneSwingRadius;
    [SerializeField] private GameObject m_DeadZoneSwingSprite;
    [SerializeField] private float m_InputZoneBallRadius;
    [SerializeField] private GameObject m_InputZoneBallSprite;
    [SerializeField] private float m_MaxDistanceSwing;

    private bool m_MovePassed = false;

    private LineRenderer m_InputDirectionRenderer;
    private LineRenderer m_CalculatedDirection;
    private float m_RenderDistanceLenght;
    private bool m_CanFollow = false;


    // Update is called once per frame
    void Update()
    {
        //Gets the start position and triggers player or camera movement
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            bool isInInputZone = CheckInInputZoneBall();

            if (touch.phase == TouchPhase.Moved)
            {
                //checking if inside or outside the deadzone
                if (!isInInputZone)
                {
                    //rotate camera if outside the inputzone
                    GameManager.instance.EventManager.TriggerEvent(Constants.UPDATE_CAMERA_ROTATION, touch.deltaPosition);
                }
            }

            //move the player if the touch is ended or canceled and the player is stopped
            else if ((touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                     && isInInputZone && m_MovePassed
                     && m_Ball.GetComponent<Rigidbody>().velocity.magnitude == 0f)
            {
                GameManager.instance.EventManager.TriggerEvent(Constants.MOVEMENT_PLAYER, m_TouchTempPosition, m_TouchEndPosition);
                m_DeadZoneSwingSprite.SetActive(false);

                GameManager.instance.EventManager.TriggerEvent(Constants.UPDATE_LEVEL_SWINGS);

                EnableDisableRenderers(false);
            }
        }
        //Gets the 2 start positions and triggers camera zooming
        else if (!CheckInInputZoneBall() && Input.touchCount == 2)
        {
            Touch touch = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);
            if (touch.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                m_TouchScreenStartPos = touch.position;
                m_TouchScreenStartPos2 = touch2.position;
            }
            if (touch.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                GameManager.instance.EventManager.TriggerEvent(Constants.UPDATE_CAMERA_ZOOMING, m_TouchScreenStartPos, m_TouchScreenStartPos2, touch.position, touch2.position);
            }

            if (touch.phase == TouchPhase.Ended || touch2.phase == TouchPhase.Ended)
            {
                GameManager.instance.EventManager.TriggerEvent(Constants.STOP_CAMERA_ZOOMING);
            }
        }
    }

    /// <summary>
    /// Show or hide the sprite and set its position
    /// </summary>
    /// <param name="Sprite"></param>
    /// <param name="position"></param>
    /// <param name="showing"></param>
    private void ShowHideSprite(GameObject Sprite, Vector3 position, bool showing)
    {
        Sprite.transform.position = new Vector3(position.x, m_Ball.transform.position.y, position.z);
        Sprite.SetActive(showing);
    }

    /// <summary>
    /// Returns the worldspace position of the touch (returns a Vector3)
    /// </summary>
    /// <param name="touch"></param>
    /// <returns></returns>
    public Vector3 GetTouchWorldSpace(Touch touch)
    {
        float distanceFromCamera = Vector3.Distance(m_Camera.position, m_Ball.position);
        // = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, distanceFromCamera));
        Vector3 touchPosition = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        // create a logical plane at this object's position
        // and perpendicular to world Y:
        Plane plane = new Plane(Vector3.up, m_Ball.position);
        float distance = 0; // this will return the distance from the camera
        if (plane.Raycast(ray, out distance))
        { // if plane hit...
            touchPosition = ray.GetPoint(distance); // get the point
                                                    // pos has the position in the plane you've touched
        }
        touchPosition.y = m_Ball.position.y;

        return touchPosition;
    }

    /// <summary>
    /// Checks if the touch is in the Ball Deadzone (returns a bool)
    /// </summary>
    /// <returns></returns>
    public bool CheckInInputZoneBall()
    {
        float distance = Vector3.Distance(m_TouchStartPosition, m_Ball.position);

        if (distance <= m_InputZoneBallRadius)
            return true;
        else
            return false;
    }

    private void CalculateWay()
    {
        Vector3 finalPoint = Vector3.zero;
        float actualLenght = 0;
        Vector3 directionBall = -(m_TouchEndPosition - m_TouchTempPosition);
        RaycastHit hit;

        m_RenderDistanceLenght = directionBall.magnitude * m_LineMultiplier;

        List<Vector3> wallHitPosition = new List<Vector3>();
        Vector3 normal;

        Physics.Raycast(m_Ball.position, directionBall.normalized, out hit);

        wallHitPosition.Add(hit.point);

        //actualLenght += Vector3.Distance(m_Ball.position, wallHitPosition[0]);
        if (actualLenght + Vector3.Distance(m_Ball.position, wallHitPosition[0]) <= m_RenderDistanceLenght)
        {
            actualLenght += Vector3.Distance(m_Ball.position, wallHitPosition[0]);

            //Debug.Log("actualLenght: " + actualLenght);

            normal = new Vector3(hit.normal.x, 0f, hit.normal.z);
            //wallHitPosition.Add(hit.point);

            Vector3 directionWall = Vector3.Reflect(directionBall.normalized, normal);

            int i = 0;
            while (actualLenght <= m_RenderDistanceLenght && finalPoint == Vector3.zero)
            {
                Physics.Raycast(wallHitPosition[i], directionWall.normalized, out hit);
                
                wallHitPosition.Add(hit.point);
                Vector3 pastDirectionWall = directionWall;
        
                directionWall = Vector3.Reflect(directionWall.normalized, normal);
                normal = new Vector3(hit.normal.x, 0f, hit.normal.z);

                //Debug.Log("totale: " + (actualLenght + Vector3.Distance(wallHitPosition[i], wallHitPosition[i + 1])));

                if (actualLenght + Vector3.Distance(wallHitPosition[i], wallHitPosition[i + 1]) >= m_RenderDistanceLenght)
                {
                    wallHitPosition.RemoveAt(i + 1);
                    finalPoint = CalcFInalPoint(actualLenght, pastDirectionWall, wallHitPosition[i]);
                    //Debug.Log("totale if: " + actualLenght);
                }
                else 
                {
                    actualLenght += Vector3.Distance(wallHitPosition[i], wallHitPosition[i + 1]);
                }
                    

                i++;
            }
        }
        else
        {
            wallHitPosition.RemoveAt(0);
            finalPoint = CalcFInalPoint(actualLenght, directionBall, m_Ball.position);
        }

        m_CalculatedDirection.positionCount = wallHitPosition.Count + 2;
        for (int j = 0; j < m_CalculatedDirection.positionCount; j++)
        {
            if (j == 0)
                m_CalculatedDirection.SetPosition(j, m_Ball.position);
            else if (j < m_CalculatedDirection.positionCount - 1)
                m_CalculatedDirection.SetPosition(j, wallHitPosition[j - 1]);
            else
                m_CalculatedDirection.SetPosition(j, finalPoint);
        }
    }

    private Vector3 CalcFInalPoint(float actualLenght, Vector3 direction, Vector3 wallHitPosition)
    {
        float distanceFromOrigin = m_RenderDistanceLenght - actualLenght;
        float factor = distanceFromOrigin / direction.magnitude;
        return wallHitPosition + direction * factor;
    }

    private void EnableDisableRenderers(bool value)
    {
        m_InputDirectionRenderer.gameObject.SetActive(value);
        m_CalculatedDirection.gameObject.SetActive(value);
    }

    public void SetCanFollow(object[] param)
    {
        m_CanFollow = true;
    }
}