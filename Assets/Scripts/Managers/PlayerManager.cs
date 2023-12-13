using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerManager : MonoBehaviour
{
    public GameObject PlayerUI;
    [HideInInspector] public bool CanPlayerMove = true;

    private void Start()
    {
        GameManager.instance.EventManager.Register(Constants.TOGGLE_PLAYER_UI, TogglePlayerUI);
    }

    public void TogglePlayerUI(object[] param)
    {
        if (PlayerUI.activeInHierarchy)
        {
            PlayerUI.SetActive(false);
            CanPlayerMove = false;
        }


        else if (!PlayerUI.activeInHierarchy)
        {
            PlayerUI.SetActive(true);
            CanPlayerMove = true;
        }
    }

    public void TogglePlayerMovement(bool toggle)
    {
        CanPlayerMove = toggle;
    }
}
