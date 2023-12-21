using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_DialogueTextBox;
    [SerializeField] private Image m_SpriteBox;

    [SerializeField] private GameObject m_NPCScreen;
    [SerializeField] private GameObject m_PlayerUIScreen;

    [SerializeField] private List<NPCDialogue> m_ItaNPCDialogueList;
    [SerializeField] private List<NPCDialogue> m_EngNPCDialogueList;

    private int m_CurrentDialogueIndex = 0;
    private int m_CurrentMonologueIndex = 0;

    private bool m_IsInEnglish = false;
    private bool m_IsPuzzle = false;

    private GameObject m_TempUIpuzzle;

    private void Start()
    {
        GameManager.instance.EventManager.Register(Constants.NPC_START_DIALOGUE, DisplayNPC);
        m_IsInEnglish = PlayerPrefs.GetInt(Constants.SET_NPC_LANGUAGE) != 0;
    }

    public void SetLanguage(object[] param)
    {
        m_IsInEnglish = PlayerPrefs.GetInt(Constants.SET_NPC_LANGUAGE) != 0;
    }

    public void ButtonDisplayNPC(int index)
    {
        m_CurrentDialogueIndex = index;
        m_NPCScreen.SetActive(true);
        m_PlayerUIScreen.SetActive(false);
        ChatNPC();
    }

    public void DisplayNPC(object[] param)
    {
        int i = (int)param[0];
        m_IsPuzzle = (bool)param[1];
        m_TempUIpuzzle = (GameObject)param[2];
        m_CurrentDialogueIndex = i;
        m_NPCScreen.SetActive(true);
        m_PlayerUIScreen.SetActive(false);
        ChatNPC();
    }

    public void ChatNPC()
    {
        if (m_CurrentMonologueIndex < m_ItaNPCDialogueList[m_CurrentDialogueIndex].NPCMonologues.Length)
        {
            StartNPCPhrase(m_CurrentDialogueIndex, m_CurrentMonologueIndex);
            m_CurrentMonologueIndex++;
        }
        else
        {
            m_CurrentMonologueIndex = 0;
            if (!m_IsPuzzle)
                m_PlayerUIScreen.SetActive(true);
            else if (m_IsPuzzle)
                m_TempUIpuzzle.SetActive(true);

            m_NPCScreen.SetActive(false);
        }
    }

    public void StartNPCPhrase(int dialogueIndex, int monologueIndex)
    {
        if (m_IsInEnglish)
        {
            m_DialogueTextBox.text = m_EngNPCDialogueList[dialogueIndex].NPCMonologues[monologueIndex].NPCPhrase;
        }
        else if (!m_IsInEnglish)
        {
            m_DialogueTextBox.text = m_ItaNPCDialogueList[dialogueIndex].NPCMonologues[monologueIndex].NPCPhrase;
        }
        m_SpriteBox.sprite = m_ItaNPCDialogueList[dialogueIndex].NPCMonologues[monologueIndex].NPCSprite;
    }
}
