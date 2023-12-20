using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Note : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private NotesID m_NoteCode;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.instance.EventManager.TriggerEvent(Constants.NOTE_PICK_UP, m_NoteCode);
    }
}
