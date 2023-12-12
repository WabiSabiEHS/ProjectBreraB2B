using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game15Manager : MonoBehaviour
{
    [SerializeField] private int m_Columns = 4;
    [SerializeField] private int m_Raws = 4;
    [SerializeField] private GameObject[] m_Tiles = new GameObject[16];
    [SerializeField] private GameObject m_EmptyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Init()
    {
        int n = 0;
        GameObject tile = m_Tiles[n];
        Vector3 lastPos = transform.position;

        for (int i = 0; i < m_Raws; i++)
        {
            for (int j = 0; j < m_Columns; j++)
            {
                tile = m_Tiles[n];
                tile.transform.position = lastPos;

                GameObject emptyObject = Instantiate(m_EmptyPrefab, lastPos, Quaternion.identity);
                emptyObject.name = "Point n: " + (n + 1);

                lastPos.x += tile.transform.localScale.x;

                n++;
                j++;
            }

            lastPos.y += tile.transform.localScale.y;
            i++;
        }
    }
}
