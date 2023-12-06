using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorTubeComponent : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string m_Color = "";

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.instance.ColorPaintingManager.ChangeSelectedColor(m_Color);
    }

}
