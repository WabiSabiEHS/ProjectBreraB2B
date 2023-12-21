using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractablePainting : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int m_DialogueIndex;

    [SerializeField] private bool m_IsPuzzle = false;
    
    [SerializeField] private List<PickUpNotes> m_Notes;
    //[SerializeField] NotesID m_PuzzleType;
    [SerializeField] private GameObject m_PuzzleUI;

    [HideInInspector] public int NotesCollectedCount = 0;
    //private bool m_IsUnlocked = false;

    //private void Start()
    //{
    //    GameManager.instance.EventManager.Register(Constants.UNLOCK_PUZZLE, UnlockPuzzle);
    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.instance.PlayerManager.CanPlayerMove = false;
        //GameManager.instance.EventManager.TriggerEvent(Constants.TOGGLE_PLAYER_UI, false);
        GameManager.instance.EventManager.TriggerEvent(Constants.NPC_START_DIALOGUE, m_DialogueIndex, true, m_PuzzleUI);
    }

    public void ActivatePuzzle()
    {
        if (m_IsPuzzle && /*m_IsUnlocked*/ UnlockPuzzle())
        {
            m_PuzzleUI.SetActive(true);
        }

        else if (!m_IsPuzzle)
        {
            GameManager.instance.EventManager.TriggerEvent(Constants.TOGGLE_PLAYER_UI, true);
            GameManager.instance.EventManager.TriggerEvent(Constants.TOGGLE_PAINTING_DESCRIPTION, true);
        }

    }

    public bool UnlockPuzzle()
    {
        //if ((NotesID)param[0] == m_PuzzleType)
        //{
        //    m_IsUnlocked = true;
        //}
        
        if (m_Notes.Count == NotesCollectedCount) return true; 
        else return false;
    }

}
