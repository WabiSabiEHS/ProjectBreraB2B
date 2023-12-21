using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITickeyHandler : MonoBehaviour
{
    [SerializeField] private bool m_IsTicket;
    private bool m_HasWon = false;

    // Start is called before the first frame update
    void Start()
    {
        m_HasWon = PlayerPrefs.GetInt(Constants.SM_BOOL_HAS_WON) != 0;
        if (m_HasWon)
        {
            gameObject.SetActive(m_IsTicket);
        }
        else
        {
            gameObject.SetActive(!m_IsTicket);
        }
    }
}
