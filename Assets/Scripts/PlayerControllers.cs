using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllers : MonoBehaviour
{

    private PlayerControls playerControls;
    private Rigidbody2D myRigidbody;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        Vector2 inputVector = ctx.ReadValue<Vector2>();
        myRigidbody.velocity = new Vector2(inputVector.x, inputVector.y);
    }
}
