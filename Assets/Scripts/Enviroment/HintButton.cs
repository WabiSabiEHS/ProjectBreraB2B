using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class HintButton : MonoBehaviour
{
    [SerializeField] private List<int> m_Hints;

    private int m_Index = 0;

    private void Start()
    {
        GameManager.instance.EventManager.Register(Constants.NPC_HINT_SET_INDEX, SetIndex);
    }

    public void DialogueHintButton()
    {
        GameManager.instance.EventManager.TriggerEvent(Constants.NPC_START_DIALOGUE, m_Hints[m_Index]);
    }

    public void SetIndex(object[] param)
    {
        m_Index = (int)param[0];
    }
}
