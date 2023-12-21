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
        GameManager.instance.EventManager.TriggerEvent(Constants.PLAY_SOUND, Constants.SFX_TAP_MINIGAME);

        //ToggleOthersClick(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        m_FollowFinger = false;
        PiecePositioning(eventData);
        //ToggleOthersClick(true);
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
            GameManager.instance.EventManager.TriggerEvent(Constants.PUZZLE_MG_PIECE_IN_PLACE);
        }

        else
        {
            GameManager.instance.EventManager.TriggerEvent(Constants.PLAY_SOUND, Constants.SFX_NEG_FEEDBACK);

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

    private void ToggleOthersClick(bool toggle)
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i) != this)
                transform.parent.GetChild(i).GetComponent<Image>().raycastTarget = toggle;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, m_DistanceRadius);
    }
}
