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
        m_Painting.NotesCollectedCount++;
        //NPCDIALOGUE EVENT HERE
        GameManager.instance.EventManager.TriggerEvent(Constants.PLAY_SOUND, Constants.SFX_CLUE_NOTE);
        gameObject.SetActive(false);
    }
}
