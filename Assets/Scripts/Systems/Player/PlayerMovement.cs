using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public bool turnedLeft = false;
    public float horizontal;
    public float vertical;
    public Sprite[] sprites;
    public SpriteRenderer render;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get input axis
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        turnedLeft = false;
        if (horizontal > 0)
        {
            // GetComponent<Animator>().Play("Right");
            render.sprite = sprites[0];
            
        }
        else if (horizontal < 0)
        {
            // GetComponent<Animator>().Play("Left");
            render.sprite = sprites[1];
            turnedLeft = true;
        }
        else if (vertical > 0)
        {
            // GetComponent<Animator>().Play("Up");
            render.sprite = sprites[2];
        }
        else if (vertical < 0)
        {
            render.sprite = sprites[3];
            // GetComponent<Animator>().Play("Down");
        }

        // Calculate movement direction
        Vector2 movement = new Vector2(horizontal, vertical);

        // Move the player
        rb.velocity = movement * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Stop the player from moving if it's colliding with a wall
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Mob"))
        {
            rb.velocity = Vector2.zero;
        }
    }
}
