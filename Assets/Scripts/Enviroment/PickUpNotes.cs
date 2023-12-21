using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUpNotes : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int m_DialogueIndex;
    [SerializeField] private InteractablePainting m_Painting;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Pick Up Note");
        m_Painting.NotesCollectedCount++;
        GameManager.instance.EventManager.TriggerEvent(Constants.NPC_START_DIALOGUE, m_DialogueIndex, false, null);
        GameManager.instance.EventManager.TriggerEvent(Constants.PLAY_SOUND, Constants.SFX_CLUE_NOTE);
        gameObject.SetActive(false);
    }
}
