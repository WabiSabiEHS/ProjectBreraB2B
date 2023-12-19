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
            GameManager.instance.EventManager.TriggerEvent(Constants.COLOR_MG_TILE_COMPLETED);
            gameObject.SetActive(false);
        }
    }
}
