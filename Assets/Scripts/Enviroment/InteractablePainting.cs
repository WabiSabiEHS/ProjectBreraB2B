using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractablePainting : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string m_Description = "";

    [SerializeField] private bool m_IsPuzzle = false;
    [SerializeField] NotesID m_PuzzleType;
    [SerializeField] private GameObject m_PuzzleUI;

    private bool m_IsUnlocked = false;

    private void Start()
    {
        GameManager.instance.EventManager.Register(Constants.UNLOCK_PUZZLE, UnlockPuzzle);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.instance.PlayerManager.CanPlayerMove = false;
        GameManager.instance.EventManager.TriggerEvent(Constants.TOGGLE_PLAYER_UI, false);
        GameManager.instance.EventManager.TriggerEvent(Constants.CHANGE_PAINTING_DESCRIPTION, m_Description, this);
    }

    public void ActivatePuzzle()
    {
        if (m_IsPuzzle && m_IsUnlocked)
        {
            m_PuzzleUI.SetActive(true);
        }

        else if (!m_IsPuzzle)
        {
            GameManager.instance.EventManager.TriggerEvent(Constants.TOGGLE_PLAYER_UI, true);
            GameManager.instance.EventManager.TriggerEvent(Constants.TOGGLE_PAINTING_DESCRIPTION, true);
        }

    }

    public void UnlockPuzzle(object[] param)
    {
        if ((NotesID)param[0] == m_PuzzleType)
        {
            m_IsUnlocked = true;
        }
    }

}
