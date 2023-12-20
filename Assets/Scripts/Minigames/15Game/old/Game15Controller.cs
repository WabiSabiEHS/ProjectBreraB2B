//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Game15Controller : MonoBehaviour
//{
//    [SerializeField] private Tile15Game m_TilePrefab;

//    private Tile15Game[,] m_Tiles = new Tile15Game[4, 4];

//    [SerializeField] private Sprite[] m_Sprites;


//    private void Start()
//    {
//        Init();    
//    }

//    private void Init()
//    { 
//        int n = 0;

//        for (int y = 3; y>=0; y--)
//        {
//            for (int x = 0; x<4; x++)
//            {
//                Tile15Game tile = Instantiate(m_TilePrefab, new Vector2(x, y), Quaternion.identity);
//                tile.Init(x, y, n + 1, m_Sprites[n], ClickToSwap);

//                m_Tiles[x, y] = tile;

//                n++;
//            }
//        }
//    }

//    private void ClickToSwap(int x, int y)
//    {
//        int dx = GetX(x, y);
//        int dy = GetY(x, y);

//        var from = m_Tiles[x, y];
//        var target = m_Tiles[x + dx, y + dy];

//        m_Tiles[x, y] = target;
//        m_Tiles[x + dx, y + dy] = from;

//        from.UpdatePos(x + dx, y + dy);
//        target.UpdatePos(x, y);
//    }

//    private int GetX(int x, int y)
//    {
//        //right empty
//        if (x < 3 && m_Tiles[x +1, y].IsEmpty())
//        {
//            return 1;
//        }

//        //left empty
//        if (x > 0 && m_Tiles[x -1, y].IsEmpty())
//        {
//            return -1;
//        }

//        return 0;
//    }
    
//    private int GetY(int x, int y)
//    {
//        //up empty
//        if (y < 3 && m_Tiles[x, y + 1].IsEmpty())
//        {
//            return 1;
//        }

//        //down empty
//        if (y > 0 && m_Tiles[x, y - 1].IsEmpty())
//        {
//            return -1;
//        }

//        return 0;
//    }
//}
