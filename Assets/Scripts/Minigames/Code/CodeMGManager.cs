using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CodeMGManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_DisplayText;

    [SerializeField] private int[] m_RightCombination;

    private int[] m_Combination;

    private int index = 0;

    private void Start()
    {
        m_Combination = new int[m_RightCombination.Length];
    }

    public void AddNumber(int number)
    {
        if (index < m_Combination.Length)
        {
            m_Combination[index] = number;
            m_DisplayText.text += number.ToString();
            index++;
        }
    }

    public void CheckWin()
    {
        GameManager.instance.EventManager.TriggerEvent(Constants.PLAY_SOUND, Constants.SFX_CODE_NUMBER_CONDITION);
        for (int i = 0; i < m_Combination.Length; i++)
        {
            m_Combination[i] = 0;
            i++;
        }
        if (CheckCombination())
        {
            GameManager.instance.EventManager.TriggerEvent(Constants.PLAY_LOOP_SOUND, Constants.MUS_ENDING);
        }
        else
        {
            GameManager.instance.EventManager.TriggerEvent(Constants.PLAY_SOUND, Constants.SFX_NEG_FEEDBACK);

            m_DisplayText.text = string.Empty;
            index = 0;
        }
    }

    private bool CheckCombination()
    {
        if (index == m_RightCombination.Length)
        {
            for (int i = 0; i < m_RightCombination.Length; i++)
            {
                if (m_Combination[i] != m_RightCombination[i]) return false;
                i++;
            }
            return true;
        }

        else return false;
    }
}
