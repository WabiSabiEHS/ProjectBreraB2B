using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {


	[SerializeField] private TextMeshProUGUI m_DialogueTextBox;
	[SerializeField] private Image m_SpriteBox;
	[SerializeField] private GameObject m_NPCScreen;
	[SerializeField] private List<Dialogue> m_DialogueList;
	[SerializeField] private List<DialogueTrigger> m_ButtonList;
	private DialogueTrigger m_CurrentButton;

	private bool m_IsInEnglish = false;

	private Dialogue m_ActualDialogue;
	private List<string> m_CurrentText;
	private Sprite m_CurrentSprite;
	private int m_CurrentMonologueIndex;

	// Use this for initialization
	private void Start () {
		GameManager.instance.EventManager.Register(Constants.START_NPC_DIALOGUE, StartNPCDialogue);
		GameManager.instance.EventManager.Register(Constants.SET_NPC_LANGUAGE, SetLanguage);
		GameManager.instance.EventManager.Register(Constants.CHANGE_BUTTON_TRIGGER, ChangeButton);
		m_CurrentText = new List<string>();
	}

	public void SetLanguage(object[] param)
	{
		m_IsInEnglish = PlayerPrefs.GetInt(Constants.SET_NPC_LANGUAGE) != 0;
	}
	public void StartNPCDialogue(object[] param)
	{
		m_NPCScreen.SetActive(true);
		StartDialogue((int)param[0]);
	}

	/// <summary>
	/// Method used for starting a specified dialogue, need an index based on the dialogue list
	/// </summary>
	/// <param name="indexDialogue"></param>
	public void StartDialogue(int indexDialogue)
	{
		if (!m_IsInEnglish)
			m_ActualDialogue = m_DialogueList[indexDialogue];
		else if (m_IsInEnglish)
			m_ActualDialogue = m_DialogueList[indexDialogue + 1];
		StartMonologue();
    }

	/// <summary>
	/// Start the monologue based on CurrentMonologueIndex and show the first sentence
	/// </summary>
	public void StartMonologue()
	{

		m_CurrentText.Clear();

		m_CurrentText.Add(null);

		foreach (string sentence in m_ActualDialogue.DialogueParts[m_CurrentMonologueIndex].Sentences)
		{
			m_CurrentText.Add(sentence);
        }

        m_CurrentSprite = m_ActualDialogue.DialogueParts[m_CurrentMonologueIndex].Sprite;

		DisplayNextSentence();
	}

	/// <summary>
	/// SHow the first sentence available in the list of CurrentText
	/// </summary>
	public void DisplayNextSentence ()
	{
        m_CurrentText.RemoveAt(0);
        if (m_CurrentText.Count == 0)
		{
			if (m_CurrentMonologueIndex < m_ActualDialogue.DialogueParts.Length - 1)
			{
				m_CurrentMonologueIndex++;
				StartMonologue();
            }
            else
			{
				EndDialogue();
				return;
			}
		}

		string sentence = m_CurrentText[0];
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
    }

	/// <summary>
	/// Type letter by letter the entire senteces passed by param in UI
	/// </summary>
	/// <param name="sentence"></param>
	/// <returns></returns>
	private IEnumerator TypeSentence (string sentence)
	{
		m_DialogueTextBox.text = "";
		m_SpriteBox.sprite = m_CurrentSprite;
		foreach (char letter in sentence.ToCharArray())
		{
			m_DialogueTextBox.text += letter;
			yield return null;
		}
	}

	/// <summary>
	/// Stop dialogue, reset all to default values and hide text box in UI
	/// </summary>
	private void EndDialogue()
	{
		m_ActualDialogue = null;
        m_CurrentMonologueIndex = 0;
		m_NPCScreen.SetActive(false);
    }

	public void ChangeButton(object[] param)
	{
		int i = (int)param[0];
		if (m_CurrentButton != null) m_CurrentButton.gameObject.SetActive(false);
		m_CurrentButton = m_ButtonList[i];
		m_CurrentButton.gameObject.SetActive(true);
	}

}