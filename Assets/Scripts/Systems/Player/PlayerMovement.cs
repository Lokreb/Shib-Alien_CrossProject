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

    private Rigidbody2D rbp;
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
        rbp = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get input axis
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rbp.velocity = new Vector2(horizontal * speed, vertical * speed);
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
        //----------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------

        if (Input.GetKeyDown("d"))
        {
            render.sprite = sprites[0];
            ShootingRight();
        }
        else if (Input.GetKeyDown("q"))
        {
            render.sprite = sprites[1];
            ShootingLeft();
        }
       else if (Input.GetKeyDown("z"))
        {
            render.sprite = sprites[2];
            ShootingUp();
        }
       else if (Input.GetKeyDown("s"))
        {
            render.sprite = sprites[3];
            ShootingDown();
        }


        // Calculate movement direction
        Vector2 movement = new Vector2(horizontal, vertical);

        // Move the player
        rbp.velocity = movement * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Stop the player from moving if it's colliding with a wall
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Mob"))
        {
            rbp.velocity = Vector2.zero;
        }
    }


    public void ShootingRight()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePointRight.position, firePointRight.rotation);
        Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();
        rbb.AddForce(firePointRight.up * bulletForce, ForceMode2D.Impulse);
    }

    public void ShootingLeft()
    {
        GameObject bullet2 = Instantiate(bulletPrefab2, firePointLeft.position, firePointLeft.rotation);
        Rigidbody2D rbb = bullet2.GetComponent<Rigidbody2D>();
        rbb.AddForce(firePointLeft.up * bulletForce, ForceMode2D.Impulse);
    }

    public void ShootingUp()
    {
        GameObject bullet3 = Instantiate(bulletPrefab3, firePointUp.position, firePointUp.rotation);
        Rigidbody2D rbb = bullet3.GetComponent<Rigidbody2D>();
        rbb.AddForce(firePointUp.up * bulletForce, ForceMode2D.Impulse);
    }

    public void ShootingDown()
    {
        GameObject bullet4 = Instantiate(bulletPrefab4, firePointDown.position, firePointDown.rotation);
        Rigidbody2D rbb = bullet4.GetComponent<Rigidbody2D>();
        rbb.AddForce(firePointDown.up * bulletForce, ForceMode2D.Impulse);
        Debug.Log(bulletForce);
    }
}
