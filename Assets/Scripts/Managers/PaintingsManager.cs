using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PaintingsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_PaintDescription;
    [SerializeField] private GameObject m_DescriptionUI;

    private InteractablePainting m_SelectedPainting;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.EventManager.Register(Constants.CHANGE_PAINTING_DESCRIPTION, ChangeDescription);
    }

    public void ChangeDescription(object[] param)
    {
        m_DescriptionUI.SetActive(true);
        m_PaintDescription.text = (string)param[0];
        m_SelectedPainting = (InteractablePainting)param[1];
    }

    public void PlayPuzzle()
    {
        m_DescriptionUI.SetActive(false);
        m_SelectedPainting.ActivatePuzzle();       
    }

}
