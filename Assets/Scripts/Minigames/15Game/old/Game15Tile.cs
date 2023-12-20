//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class Game15Tile : MonoBehaviour, IPointerDownHandler
//{
//    [HideInInspector] public Game15Image m_Image;
//    public int m_Xpos;
//    public int m_Ypos;

//    private void Start()
//    {
//        GameManager.instance.EventManager.Register(Constants.GAME15_CHANGE_IMAGE, ChangeImage);
//    }

//    public void ChangeImage(object[] param)
//    {
//        m_Image = (Game15Image)param[0];
//        if (m_Image != null)
//        {
//            m_Image.transform.position = transform.position;
//        }
//    }

//    public void OnPointerDown(PointerEventData eventData)
//    {
        
//    }
//}
