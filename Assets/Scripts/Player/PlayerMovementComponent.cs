using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementComponent : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        Vector3 direction = new Vector3(InputManager.MovementAxis.x, 0, InputManager.MovementAxis.y);
        transform.position += direction * (speed * Time.deltaTime);
    }
}
