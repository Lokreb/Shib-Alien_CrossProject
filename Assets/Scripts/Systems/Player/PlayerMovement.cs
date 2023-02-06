using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get input axis
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector2 movement = new Vector2(horizontal, vertical);

        // Move the player
        rb.velocity = movement * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Stop the player from moving if it's colliding with a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity = Vector2.zero;
        }
    }
}
