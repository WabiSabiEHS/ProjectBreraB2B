using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    [SerializeField] private Transform m_RightPosition;
    [SerializeField] private float m_DistanceRadius;
    private bool m_FollowFinger = false;
    private Vector3 m_StartingPos;

    void Start()
    {
        m_StartingPos = transform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_FollowFinger = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        m_FollowFinger = false;
        PiecePositioning(eventData);
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (m_FollowFinger)
        {
            transform.position = eventData.position;
        }
    }

    private void PiecePositioning(PointerEventData eventData)
    {
        if (Vector2.Distance(transform.position, m_RightPosition.position) <= m_DistanceRadius)
        {
            transform.position = m_RightPosition.position;
            gameObject.GetComponent<Image>().raycastTarget = false;
        }

        else
        {
            bool touchedPuzzle = false;
            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raycastResults);
            
            foreach (var collider in raycastResults)
            {
                if (collider.gameObject.TryGetComponent(out Puzzle puzzle))
                {
                    Debug.Log("PUZZLE!!!!!!!!");
                    touchedPuzzle = true;
                    break;
                }

            
            }
            if (!touchedPuzzle)
            {
                Debug.Log("NOT PUZZLE");
                transform.position = m_StartingPos;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, m_DistanceRadius);
    }
}
