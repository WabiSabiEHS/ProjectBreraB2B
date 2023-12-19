using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPaintingManager : MonoBehaviour
{
    [SerializeField] private int m_TilesCount;

    [SerializeField] private List<string> m_Colors = new List<string>();

    private Dictionary<string, int> m_ColorIDList = new Dictionary<string, int>();

    private int m_TilesCompletedCount = 0;
    private int m_SelectedColor = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.EventManager.Register(Constants.COLOR_MG_CHANGE_SELECTED_COLOR, ChangeSelectedColor);
        GameManager.instance.EventManager.Register(Constants.COLOR_MG_TILE_COMPLETED, CompletedTile);

        for (int i = 0; i < m_Colors.Count; i++)
        {
            m_ColorIDList.Add(m_Colors[i], i);
        }
    }

    public void ChangeSelectedColor(object[] param)
    {
        m_SelectedColor = m_ColorIDList[(string)param[0]];
        Debug.Log("Color = " + (string)param[0]);
    }

    public bool DeletePiece(string color)
    {
        if (m_SelectedColor == m_ColorIDList[color])
        {
            return true;
        }

        else return false;
    }

    public void CompletedTile(object[] param)
    {
        m_TilesCompletedCount++;
        if (m_TilesCompletedCount == m_TilesCount)
        {
            Debug.Log("WIN PUZZLE");
        }
    }
}
