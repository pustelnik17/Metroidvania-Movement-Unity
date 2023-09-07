using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellManager : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    Vector2 castInput;
    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        playerRigidBody.AddForce(castInput.x * 10 * Vector2.up, ForceMode2D.Impulse);
    }

    public void OnCast(InputAction.CallbackContext value)
    {
        castInput = value.ReadValue<Vector2>();
    }
}
