using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game15Tile : MonoBehaviour
{
    private GameObject m_Image;

    private void Start()
    {
        GameManager.instance.EventManager.Register(Constants.GAME15_CHANGE_IMAGE, ChangeImage);
    }

    public void ChangeImage(object[] param)
    {
        m_Image = (GameObject)param[0];
        m_Image.transform.position = transform.position;
    }
}
