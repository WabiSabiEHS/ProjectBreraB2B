using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesManager : MonoBehaviour
{
    [Tooltip("0: GO15\n1: Jigsaw\n 2: Color Painting\n 3: Code")]
    [SerializeField] public int[] m_NoteCount = new int[4];

    private int m_GO15Notes;
    private int m_JigsawNotes;
    private int m_ColorNotes;
    private int m_CodeNotes;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.EventManager.Register(Constants.NOTE_PICK_UP, StoreNote);
    }

    public void StoreNote(object[] param)
    {
        bool trigger = false;

        switch ((NotesID)param[0])
        {
            case NotesID.GameOf15:
                m_GO15Notes++;
                if (m_GO15Notes == m_NoteCount[0]) trigger = true;
                break;

            case NotesID.Jigsaw:
                m_JigsawNotes++;
                if (m_JigsawNotes == m_NoteCount[1]) trigger = true;
                break;

            case NotesID.ColorMatch:
                m_ColorNotes++;
                if (m_ColorNotes == m_NoteCount[2]) trigger = true;
                break;

            case NotesID.Code:
                m_CodeNotes++;
                if (m_CodeNotes == m_NoteCount[3]) trigger = true;
                break;
        }

        if (trigger)
        {
            GameManager.instance.EventManager.TriggerEvent(Constants.ACTIVATE_PUZZLE, (NotesID)param[0]);
        }
    }
}

public enum NotesID
{
    GameOf15,
    Jigsaw,
    ColorMatch,
    Code
}
