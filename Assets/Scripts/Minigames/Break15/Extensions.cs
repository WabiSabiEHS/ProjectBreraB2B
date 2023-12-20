using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extensions
{
    public static T GetComponentUI<T>(Vector2 _direction, float _offset) where T : class
    {
        var pointerData = new PointerEventData(EventSystem.current)
        {
            position = new Vector2(UnityEngine.Input.mousePosition.x + (_direction.x * _offset),
                UnityEngine.Input.mousePosition.y + (_direction.y * _offset))
        };
            
        List<RaycastResult> results = new List<RaycastResult>();
            
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (var raycastResult in results)
        {
            if (raycastResult.gameObject.TryGetComponent(out T component))
            {
                return component;
            }
        }

        return null;
    }

}
