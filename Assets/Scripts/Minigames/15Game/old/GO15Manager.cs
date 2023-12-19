using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GO15Manager : MonoBehaviour
{
    [SerializeField] private GO15Tile[] m_TileList = new GO15Tile[16];
    private GO15Tile[,] m_Grid = new GO15Tile[4, 4];

    void Start()
    {
        GameManager.instance.EventManager.Register(Constants.GO15_MG_SWAP_TILES, CheckNeighboringObjects);
        GameManager.instance.EventManager.Register(Constants.GO15_MG_CHECK_WIN, CheckWin);
        Init();
    }

    private void Init()
    {
        int n = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                m_Grid[i, j] = m_TileList[n];
                //m_Grid[j, i] = gameObject.transform.GetChild(n).GetComponent<GO15Tile>();
                //m_TileList[n] = m_Grid[i, j];
                m_TileList[n].SetRowAndColumn(j, i);
                n++;
                j++;
            }
            i++;
        }
    }

    public void SwapTile(GO15Tile selectedTile, GO15Tile targetTile)
    {
        int rowS, columnS, rowT, columnT;

        Vector3 previousPos = selectedTile.transform.position;
        Vector3 targetPos = targetTile.transform.position;

        //get selected tile pos in grid
        rowS = selectedTile.GetRow();
        columnS = selectedTile.GetColumn();

        //get target tile pos in grid
        rowT = targetTile.GetRow();
        columnT = targetTile.GetColumn();

        //set selected tile pos in grid and worldSpace
        selectedTile.transform.position = targetPos;
        selectedTile.SetRowAndColumn(rowT, columnT);
        m_Grid[rowT, columnT] = selectedTile;

        //set target tile pos in grid and worldSpace
        targetTile.transform.position = previousPos;
        targetTile.SetRowAndColumn(rowS, columnS);
        m_Grid[rowS, columnS] = targetTile;
    }

    public void CheckNeighboringObjects(object[] param)
    {
        GO15Tile selectedTile = m_Grid[(int)param[0], (int)param[1]];
        GO15Tile targetTile = null;

        //check up
        if (selectedTile.GetRow() < 3)
        {
            if (m_Grid[(int)param[0] + 1, (int)param[1]].IsEmpty)
            {
                targetTile = m_Grid[(int)param[0] + 1, (int)param[1]];
            }
        }

        //check down
        if (selectedTile.GetRow() > 0)
        {
            if (m_Grid[(int)param[0] - 1, (int)param[1]].IsEmpty)
            {
                targetTile = m_Grid[(int)param[0] - 1, (int)param[1]];
            }

        }

        //check right
        if (selectedTile.GetColumn()  < 3)
        {
            if (m_Grid[(int)param[0], (int)param[1] + 1].IsEmpty)
            {
                targetTile = m_Grid[(int)param[0], (int)param[1] + 1];
            }

        }

        //check left
        if (selectedTile.GetColumn() > 0)
        {
            if (m_Grid[(int)param[0], (int)param[1] - 1])
            {
                targetTile = m_Grid[(int)param[0], (int)param[1] - 1];
            }
        }

        if (targetTile != null)
            SwapTile(selectedTile, targetTile);
    }

    public void CheckWin(object[] param)
    {
        foreach (GO15Tile tile in m_TileList)
        {
            if (!tile.IsInPosition) return;
        }

        Debug.Log("WIN GAME OF 15");
    }
}
