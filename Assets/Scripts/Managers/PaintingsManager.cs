using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PaintingsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_PaintDescription;
    [SerializeField] private GameObject m_DescriptionUI;
    [SerializeField] private List<GameObject> m_NotesList;

    private InteractablePainting m_SelectedPainting;
    private bool m_CanOperDescription = true;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.EventManager.Register(Constants.CHANGE_PAINTING_DESCRIPTION, ChangeDescription);
        GameManager.instance.EventManager.Register(Constants.TOGGLE_PAINTING_DESCRIPTION, ToggleOpenDescription);
        GameManager.instance.EventManager.Register(Constants.ACTIVATE_NEW_NOTES, ActivateNewNotes);
    }

    public void ActivateNewNotes(object[] param)
    {
        int i = (int)param[0];
        m_NotesList[i].SetActive(true);
    }

    public void ChangeDescription(object[] param)
    {
        if (m_CanOperDescription)
        {
            m_DescriptionUI.SetActive(true);
            m_PaintDescription.text = (string)param[0];
            m_SelectedPainting = (InteractablePainting)param[1];
            m_CanOperDescription = false;
        }
    }

    public void CanOpenDescription()
    {
        m_CanOperDescription = true;
    }

    public void ToggleOpenDescription(object[] param)
    {
        m_CanOperDescription = (bool)param[0];
    }

    public void PlayPuzzle()
    {
        m_DescriptionUI.SetActive(false);
        m_SelectedPainting.ActivatePuzzle();       
    }

}
