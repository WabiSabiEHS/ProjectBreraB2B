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
            if (CheckCombination())
            {
                Debug.Log("CODE MG WON!!!");
            }
        }
    }

    public void ResetGame()
    {
        for (int i = 0; i < m_Combination.Length; i++)
        {
            m_Combination[i] = 0;
            i++;
        }
        m_DisplayText.text = string.Empty;
        index = 0;
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
