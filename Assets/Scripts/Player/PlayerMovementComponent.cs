using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementComponent : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Rigidbody m_RigidBody;

    private void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GameManager.instance.m_CanPlayerMove)
        {
            if (InputManager.MovementAxis.x != 0f || InputManager.MovementAxis.y != 0f)
            {
                Vector3 horizontal = transform.right * InputManager.MovementAxis.x * speed;
                Vector3 vertical = transform.forward * InputManager.MovementAxis.y * speed;

                m_RigidBody.velocity = vertical + horizontal;
            }
        }
    }
}
