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
    public Transform firePointRight;
    public Transform firePointLeft;
    public Transform firePointDown;
    public Transform firePointUp;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    public GameObject bulletPrefab4;

    public float bulletForce = 50f;

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
            if(Input.GetKeyDown("space"))
            {
                ShootingRight();
            }
            
        }
        else if (horizontal < 0)
        {
            // GetComponent<Animator>().Play("Left");
            render.sprite = sprites[1];
            turnedLeft = true;
            if(Input.GetKeyDown("space"))
            {
                ShootingLeft();
            }
        }
        else if (vertical > 0)
        {
            // GetComponent<Animator>().Play("Up");
            render.sprite = sprites[2];
            if(Input.GetKeyDown("space"))
            {
                ShootingUp();
            }
        }
        else if (vertical < 0)
        {
            render.sprite = sprites[3];
            if(Input.GetKeyDown("space"))
            {
                ShootingDown();
            }
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


    public void ShootingRight()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePointRight.position, firePointRight.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointRight.up * bulletForce, ForceMode2D.Impulse);
    }

    public void ShootingLeft()
    {
        GameObject bullet2 = Instantiate(bulletPrefab2, firePointLeft.position, firePointLeft.rotation);
        Rigidbody2D rb = bullet2.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointLeft.up * bulletForce, ForceMode2D.Impulse);
    }

    public void ShootingUp()
    {
        GameObject bullet3 = Instantiate(bulletPrefab3, firePointUp.position, firePointUp.rotation);
        Rigidbody2D rb = bullet3.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointUp.up * bulletForce, ForceMode2D.Impulse);
    }

    public void ShootingDown()
    {
        GameObject bullet4 = Instantiate(bulletPrefab4, firePointDown.position, firePointDown.rotation);
        Rigidbody2D rb = bullet4.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointDown.up * bulletForce, ForceMode2D.Impulse);
    }
}
