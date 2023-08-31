using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private Rigidbody2D playerRigidBody;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        playerRigidBody.AddForce(Vector2.right *  movementSpeed);
    }
}
