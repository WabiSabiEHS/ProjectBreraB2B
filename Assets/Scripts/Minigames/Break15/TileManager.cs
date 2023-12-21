using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class TileManager : MonoBehaviour
{
    public List<Sprite> Sprites = new List<Sprite>();

    public BreakTile prefab;
    public BreakTile[,] tiles = new BreakTile[4,4];

    public static event Action OnGameWon;
    
    private int InversionsCount;

    private void OnEnable()
    {
        BreakTile.OnTileMoved += OnTileMoved;
    }
    private void Start()
    {
        int val = 1;
        
        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                var position = new Vector2(x, -y);
                
                tiles[x,y] = Instantiate(prefab, transform);

                var rectTransform = tiles[x, y].GetComponent<RectTransform>();
                rectTransform.anchoredPosition = (position * rectTransform.rect.width) - new Vector2(rectTransform.rect.width * 1.5f, - rectTransform.rect.height * 1.5f);
                
                tiles[x,y].Init(val, x, y, Sprites[val - 1]);
                
                val++;
            }
        }

        for (int n = 0; n < 20; n++)
        {
            BreakTile tile = tiles[UnityEngine.Random.Range(0,4), UnityEngine.Random.Range(0, 4)];
            if (tile.Value != 16) 
            {
                Shuffle(tile);
            }
        }

        if (!IsSolvable())
        {
            SwapTiles(tiles[0, 0], tiles[3, 3]);
        }
    }

    private void OnDisable()
    {
        BreakTile.OnTileMoved -= OnTileMoved;
    }

    private void OnTileMoved(BreakTile _tile)
    {
        List<Vector2> directions = new List<Vector2>()
        {
            Vector2.up,
            Vector2.down,
            Vector2.right,
            Vector2.left,
        };

        foreach (var direction in directions)
        {
            int x = _tile.Y + (int)direction.y;
            int y = _tile.X + (int)direction.x;
            
            if(x > 3 || y > 3) continue;
            if(x < 0 || y < 0) continue;
            
            var neighborTile = tiles[y,x];
            
            if (neighborTile.Value == 16)
            {
                SwapTiles(_tile, neighborTile);

                GameManager.instance.EventManager.TriggerEvent(Constants.PLAY_SOUND, Constants.SFX_GAME_15);
                
                CheckWinCondition();

                return;
            }
        }
    }

    private void SwapTiles(BreakTile _tile, BreakTile neighborTile)
    {
        var tempX = neighborTile.X;
        var tempY = neighborTile.Y;
        var tempPos = neighborTile.RectTransform.anchoredPosition;

        neighborTile.X = _tile.X;
        neighborTile.Y = _tile.Y;
        neighborTile.RectTransform.anchoredPosition = _tile.RectTransform.anchoredPosition;

        _tile.X = tempX;
        _tile.Y = tempY;
        _tile.RectTransform.anchoredPosition = tempPos;

        tiles[tempX, tempY] = _tile;
        tiles[neighborTile.X, neighborTile.Y] = neighborTile;
    }

    private void CheckWinCondition()
    {
        int val = 1;
        
        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                int value = tiles[x, y].Value;
                
                Debug.Log($"Value at pos X: {x} Y: {y} | {value} | {val}");
                
                if (value != val)
                {
                    return;
                }

                val++;
            }
        }

        GameManager.instance.EventManager.TriggerEvent(Constants.PLAY_SOUND, Constants.SFX_WIN_CONDITION);
        GameManager.instance.EventManager.TriggerEvent(Constants.ACTIVATE_NEW_NOTES, 2);
        Debug.Log("Won!");
        
        OnGameWon?.Invoke();
    }


    private void Shuffle(BreakTile _tile)
    {
        List<Vector2> directions = new List<Vector2>()
        {
            Vector2.up,
            Vector2.down,
            Vector2.right,
            Vector2.left,
        };

        Vector2 direction = directions[UnityEngine.Random.Range(0, 4)];

        int x = _tile.Y + (int)direction.y;
        int y = _tile.X + (int)direction.x;

        if (x > 3 || y > 3) return;
        if (x < 0 || y < 0) return;

        var neighborTile = tiles[y, x];

        if (neighborTile.Value != 16)
        {
            var tempX = neighborTile.X;
            var tempY = neighborTile.Y;
            var tempPos = neighborTile.RectTransform.anchoredPosition;

            neighborTile.X = _tile.X;
            neighborTile.Y = _tile.Y;
            neighborTile.RectTransform.anchoredPosition = _tile.RectTransform.anchoredPosition;

            _tile.X = tempX;
            _tile.Y = tempY;
            _tile.RectTransform.anchoredPosition = tempPos;

            tiles[tempX, tempY] = _tile;
            tiles[neighborTile.X, neighborTile.Y] = neighborTile;

            InversionsCount++;

            return;
        }
        
    }


    private bool IsSolvable()
    {
        bool isSolvable;

        var EmptyTile = tiles[3, 3];    

        isSolvable = InversionsCount % 2 != 0 && EmptyTile.Y % 2 != 0;

        return isSolvable;
    }
}
