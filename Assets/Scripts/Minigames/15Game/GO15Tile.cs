using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GO15Tile : MonoBehaviour, IPointerDownHandler
{
    public bool IsEmpty = false;
    [HideInInspector] public bool IsInPosition = false;

    [SerializeField] private int m_RightRow;
    [SerializeField] private int m_RightColumn;

    [SerializeField] private int m_Row;
    [SerializeField] private int m_Column;
    

    public int GetRow() => m_Row;

    public int GetColumn() => m_Column;


    public void SetRowAndColumn(int row, int column)
    {
        m_Row = row;
        m_Column = column;
    }

    private void CheckRightPos()
    {
        if (m_RightRow == m_Row && m_RightColumn == m_Column) 
            IsInPosition = true;

        else if (m_RightRow != m_Row || m_RightColumn != m_Column) 
            IsInPosition = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.instance.EventManager.TriggerEvent(Constants.GO15_MG_SWAP_TILES, m_Row, m_Column);
        CheckRightPos();
        GameManager.instance.EventManager.TriggerEvent(Constants.GO15_MG_CHECK_WIN);
    }
}
