using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllers : MonoBehaviour
{

    private PlayerControls playerControls;
    private Rigidbody2D myRigidbody;
    public float speed =2;
    public float acc = 1;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        //playerControls.Gameplay.Movement_2.performed += ctx => Move_2(ctx);
        //Debug.Log(transform.position);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        speed = 2;
        Vector2 inputVector = ctx.ReadValue<Vector2>();
        //Vector2 speedVector = ctx.ReadValue<Vector2>();
        //speed = Mathf.Abs(speedVector.x)+Mathf.Abs(speedVector.y);
        //acc = Mathf.Abs(inputVector.x)+Mathf.Abs(inputVector.y);
        //speed = speed + acc*Time.deltaTime*8;
        myRigidbody.velocity = new Vector2(speed*inputVector.x, speed*inputVector.y);
        //Debug.Log(inputVector.x);

        if(inputVector.x==1)
        {
            Debug.Log("Droite");
        }
        if(inputVector.x==-1)
        {
            Debug.Log("Gauche");
        }
        if(inputVector.y==1)
        {
            Debug.Log("Haut");
        }
        if(inputVector.y==-1)
        {
            Debug.Log("Bas");
        }
    }
}
