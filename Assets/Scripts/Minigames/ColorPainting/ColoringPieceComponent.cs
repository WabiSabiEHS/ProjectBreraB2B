using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColoringPieceComponent : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string m_RightColor = "";

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.instance.ColorPaintingManager.DeletePiece(m_RightColor))
        {
            gameObject.SetActive(false);
        }
    }
}
