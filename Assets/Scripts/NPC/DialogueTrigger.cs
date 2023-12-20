using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour 
{
	[SerializeField] private DialogueManager m_DialogueManager;

	[SerializeField] private int[] m_DialogueIndexes;
	private int m_Index = 0;

	public void CheckToStop(int index)
	{
		if (index == m_Index)
		{
			GameManager.instance.EventManager.TriggerEvent(Constants.CHANGE_BUTTON_TRIGGER, index);
		}

		else return;
	}

	public void ButtonDialogue()
	{
		TriggerDialogue(m_DialogueIndexes[m_Index]);
		m_Index++;
	}

	/// <summary>
	/// method used to trigger a dialogue, need the index of the specified dialogue
	/// </summary>
	/// <param name="indexDialogue"></param>
	public void TriggerDialogue (int indexDialogue)
	{
        m_DialogueManager.StartDialogue(indexDialogue);
	}
}