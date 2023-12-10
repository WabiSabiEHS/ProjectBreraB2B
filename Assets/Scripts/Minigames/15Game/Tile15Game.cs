using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile15Game : MonoBehaviour, IPointerDownHandler
{
    public int Index = 0;
    private int m_Xpos = 0;
    private int m_Ypos = 0;

    private Action<int, int> m_SwapFunc = null;

    public void Init(int i, int j, int index, Sprite sprite, Action<int, int> swapFunc)
    {
        this.Index = index;
        UpdatePos(i, j);
        this.GetComponent<SpriteRenderer>().sprite = sprite;
        this.m_SwapFunc = swapFunc;
    }

    public void UpdatePos(int i, int j)
    {
        m_Xpos = i;
        m_Ypos = j;
        this.gameObject.transform.localPosition = new Vector2(i, j);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (m_SwapFunc != null)
        {
            m_SwapFunc(m_Xpos, m_Ypos);
        }
    }
 
    public bool IsEmpty()
    {
        if(Index == 16) return true;
        else return false;
    }
}