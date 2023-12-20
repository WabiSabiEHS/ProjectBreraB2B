//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Game15Manager : MonoBehaviour
//{
//    [SerializeField] private int m_Columns = 4;
//    [SerializeField] private int m_Raws = 4;
//    [SerializeField] private Game15Tile[] m_Tiles = new Game15Tile[16];
//    [SerializeField] private Game15Image[] m_Images = new Game15Image[16];
//    private int[,] m_GridPosition = new int[4,4];

//    // Start is called before the first frame update
//    void Start()
//    {
//        Init();
        
//    }

//    private void Init()
//    {
//        int n = 0;
//        Game15Tile tile = m_Tiles[n];
//        Vector3 lastPos = transform.position;
//        Vector3 nextPos = transform.position;

//        for (int i = 0; i < m_Raws; i++)
//        {
//            for (int j = 0; j < m_Columns; j++)
//            {
//                tile = m_Tiles[n];
//                tile.transform.position = nextPos;

//                GameManager.instance.EventManager.TriggerEvent(Constants.GAME15_CHANGE_IMAGE, m_Images[n]);

//                nextPos.x += m_Images[n].transform.localScale.x;

//                n++;
//                j++;
//            }
//            nextPos.x = lastPos.x;
//            nextPos.y += m_Images[n].transform.localScale.y;
//            i++;    
//        }
//    }

//    public void SwapImage(object[] param)
//    {
//        Game15Tile tile = (Game15Tile)param[0];
//    }
//}
