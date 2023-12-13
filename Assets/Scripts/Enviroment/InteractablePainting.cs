using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractablePainting : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string m_Description = "";

    [SerializeField] private bool m_IsPuzzle = false;
    [SerializeField] private GameObject m_PuzzleUI;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.instance.PlayerManager.CanPlayerMove = false;
        GameManager.instance.EventManager.TriggerEvent(Constants.TOGGLE_PLAYER_UI);
        GameManager.instance.EventManager.TriggerEvent(Constants.CHANGE_PAINTING_DESCRIPTION, m_Description, this);
    }

    public void ActivatePuzzle()
    {
        if (m_IsPuzzle)
        {
            m_PuzzleUI.SetActive(true);
        }

        else if (!m_IsPuzzle)
        {
            GameManager.instance.EventManager.TriggerEvent(Constants.TOGGLE_PLAYER_UI);
        }

    }

}
