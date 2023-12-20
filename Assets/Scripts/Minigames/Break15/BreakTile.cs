using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BreakTile : MonoBehaviour, IPointerClickHandler
{
    private Image ImageSprite;
    
    public int Value = 0;
    public int X;
    public int Y;

    private RectTransform rectTransform;
    public RectTransform RectTransform => rectTransform;
    
    public static event Action<BreakTile> OnTileMoved; 

    private void Awake()
    {
        ImageSprite = GetComponentInChildren<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void Init(int value, int x, int y, Sprite sprite)
    {
        Value = value;
        X = x;
        Y = y;

        ImageSprite.sprite = sprite;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        OnTileMoved?.Invoke(this);
    }
}
