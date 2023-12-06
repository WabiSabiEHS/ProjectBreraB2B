using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        PiecePositioning();
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (m_FollowFinger)
        {
            transform.position = eventData.position;
        }
    }

    private void PiecePositioning()
    {
        if (Vector2.Distance(transform.position, m_RightPosition.position) <= m_DistanceRadius)
        {
            transform.position = m_RightPosition.position;
        }

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, m_DistanceRadius);
    }
}
