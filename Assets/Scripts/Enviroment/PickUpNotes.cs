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
        gameObject.SetActive(false);
    }
}
