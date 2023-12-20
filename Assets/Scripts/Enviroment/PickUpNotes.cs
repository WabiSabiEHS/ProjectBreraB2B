using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUpNotes : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int m_DialogueIndex;

    public void OnPointerClick(PointerEventData eventData)
    {
        //NPCDIALOGUE EVENT HERE
        gameObject.SetActive(false);
    }
}
