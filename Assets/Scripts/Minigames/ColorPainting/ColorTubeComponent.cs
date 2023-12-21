using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorTubeComponent : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string m_Color = "";

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.instance.EventManager.TriggerEvent(Constants.PLAY_SOUND, Constants.SFX_TAP_MINIGAME);

        GameManager.instance.EventManager.TriggerEvent(Constants.COLOR_MG_CHANGE_SELECTED_COLOR, m_Color);
    }

}
