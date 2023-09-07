using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxVelocity = 1f;
    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float jumpImpulse = 1f;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D playerRigidBody;
    private Vector2 moveInput;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        playerRigidBody.AddForce((moveInput.x * maxVelocity - playerRigidBody.velocity.x) * acceleration * Vector2.right, ForceMode2D.Force);

        if (Physics2D.OverlapBox(groundCheck.transform.position, groundCheck.transform.localScale, 0, groundLayer))
        {
            playerRigidBody.AddForce(moveInput.y * jumpImpulse * Vector2.up, ForceMode2D.Impulse);
        }
        else
        {
            playerRigidBody.AddForce(moveInput.y * jumpForce * Vector2.up, ForceMode2D.Force);
        }

        if(playerRigidBody.velocity.y < 0)
        {
            playerRigidBody.gravityScale = 1.5f;
        }
        else
        {
            playerRigidBody.gravityScale = 1f;
        }
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        moveInput = value.ReadValue<Vector2>();
    }
}