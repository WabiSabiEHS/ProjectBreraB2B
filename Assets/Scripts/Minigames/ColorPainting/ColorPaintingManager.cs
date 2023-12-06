using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPaintingManager : MonoBehaviour
{
    [SerializeField] private List<string> m_Colors = new List<string>();

    private Dictionary<string, int> m_ColorIDList = new Dictionary<string, int>();

    private int m_SelectedColor = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < m_Colors.Count; i++)
        {
            m_ColorIDList.Add(m_Colors[i], i);
        }
    }

    public void ChangeSelectedColor(string Color)
    {
        m_SelectedColor = m_ColorIDList[Color];
        Debug.Log("Color = " + Color);
    }

    public bool DeletePiece(string rightColor)
    {
        if (m_SelectedColor == m_ColorIDList[rightColor])
        {
            return true;
        }

        else return false;
    }
}
