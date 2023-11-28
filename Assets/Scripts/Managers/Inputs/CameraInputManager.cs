using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraInputManager : MonoBehaviour
{
    private Vector2 m_TouchScreenStartPos;
    private Vector2 m_TouchScreenStartPos2;
    private bool m_IsInInputZone = false;

    [SerializeField] private GameObject m_JoyStick;
    [SerializeField] private float m_JoyStickOffSetRadius;

    // Update is called once per frame
    void Update()
    {
        //Gets the start position and triggers player or camera movement
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                m_TouchScreenStartPos = touch.position;
                m_IsInInputZone = CheckInInputZone(m_TouchScreenStartPos);
            }

            if (touch.phase == TouchPhase.Moved && !m_IsInInputZone)
            {
                //checking if inside or outside the deadzone
                /*if (!isInInputZone)
                {*/
                    //rotate camera if outside the inputzone
                    GameManager.instance.EventManager.TriggerEvent(Constants.UPDATE_CAMERA_ROTATION, touch.deltaPosition);
                /*}*/
            }
        }
        //Gets the 2 start positions and triggers camera zooming
        else if (/*!CheckInInputZone() &&*/ Input.touchCount == 2)
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
    /// Returns the worldspace position of the touch (returns a Vector3)
    /// </summary>
    /// <param name="touch"></param>
    /// <returns></returns>
    //public Vector3 GetTouchWorldSpace(Touch touch)
    //{
    //    float distanceFromCamera = Vector3.Distance(m_Camera.position, m_Ball.position);
    //    // = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, distanceFromCamera));
    //    Vector3 touchPosition = Vector3.zero;
    //    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
    //    // create a logical plane at this object's position
    //    // and perpendicular to world Y:
    //    Plane plane = new Plane(Vector3.up, m_Ball.position);
    //    float distance = 0; // this will return the distance from the camera
    //    if (plane.Raycast(ray, out distance))
    //    { // if plane hit...
    //        touchPosition = ray.GetPoint(distance); // get the point
    //                                                // pos has the position in the plane you've touched
    //    }
    //    touchPosition.y = m_Ball.position.y;

    //    return touchPosition;
    //}

    /// <summary>
    /// Checks if the touch is in the Ball Deadzone (returns a bool)
    /// </summary>
    /// <returns></returns>
    public bool CheckInInputZone(Vector2 touch)
    {
        float TouchDistance = Vector2.Distance(touch, m_JoyStick.transform.position);

        if (TouchDistance > m_JoyStickOffSetRadius)
            return false;

        else 
            return true;
    }
}