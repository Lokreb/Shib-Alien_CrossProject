using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public bool turnedLeft = false;
    private float horizontal;
    private float vertical;
    public SpriteRenderer render;
    public bool IsAlive = true;
    private Rigidbody2D rbp;
    public Transform firePointRight;
    public Transform firePointLeft;
    public Transform firePointDown;
    public Transform firePointUp;
    public GameObject bulletPrefab;
    private bool isshooting = false;
    public float bulletForce = 50f;
    public float AtkSpeed = 1f;
    private WaitForSeconds atkDelaiDuration;
    public int degats = 1;
    public float Portee = 1f;
    public Sprite[] sprites;
   

    private void Start()
    {
        rbp = GetComponent<Rigidbody2D>();
        atkDelaiDuration = new WaitForSeconds(1/AtkSpeed);
       
    }

    private void Update()
    {
        
        // Get input axis
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        rbp.velocity = new Vector2(horizontal * speed, vertical * speed);
        turnedLeft = false;
        shootOrNot();
        shootingEye();
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
        
        
    }

    public void ShootingLeft()
    {
        GameObject bullet2 = Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);
        if (bullet2.GetComponent<Bullet>() != null)
        {
            bullet2.GetComponent<Bullet>().Dmg = degats;
        }
        Rigidbody2D rbb = bullet2.GetComponent<Rigidbody2D>();
        rbb.AddForce(firePointLeft.up * bulletForce, ForceMode2D.Impulse);

        
    }

    public void ShootingUp()
    {
        GameObject bullet3 = Instantiate(bulletPrefab, firePointUp.position, firePointUp.rotation);
        Rigidbody2D rbb = bullet3.GetComponent<Rigidbody2D>();
        rbb.AddForce(firePointUp.up * bulletForce, ForceMode2D.Impulse);
       
    }

    public void ShootingDown()
    {
        GameObject bullet4 = Instantiate(bulletPrefab, firePointDown.position, firePointDown.rotation);
        Rigidbody2D rbb = bullet4.GetComponent<Rigidbody2D>();
        rbb.AddForce(firePointDown.up * bulletForce, ForceMode2D.Impulse);
        Debug.Log(bulletForce);
        
    }

    public void shootingEye()
    {

        if (isshooting)
        {
            if (Input.GetKeyDown("d"))
            {
                render.sprite = sprites[0];

            }
            else if (Input.GetKeyDown("q"))
            {
                render.sprite = sprites[1];

            }
            else if (Input.GetKeyDown("z"))
            {
                render.sprite = sprites[2];

            }
            else if (Input.GetKeyDown("s"))
            {
                render.sprite = sprites[3];

            }
        }
        else if (!isshooting)
        {
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
        }



    }

    public void shootOrNot()
    {

        if (Input.GetKeyDown("d") && !isshooting)
        {
            isshooting = true;
            GameObject bullet = Instantiate(bulletPrefab, firePointRight.position, firePointRight.rotation);
            if (bullet.GetComponent<Bullet>() != null)
            {
                bullet.GetComponent<Bullet>().Dmg = degats;
                bullet.GetComponent<Bullet>().lifetime = Portee;
            }
            Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();
            rbb.AddForce(firePointRight.up * bulletForce, ForceMode2D.Impulse);
            StartCoroutine(ShootingTime());
        }
        else if (Input.GetKeyDown("q") && !isshooting)
        {
            isshooting = true;
            GameObject bullet = Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);

            if (bullet.GetComponent<Bullet>() != null)
            {
                bullet.GetComponent<Bullet>().Dmg = degats;
                bullet.GetComponent<Bullet>().lifetime = Portee;
            }
            Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();
            rbb.AddForce(firePointLeft.up * bulletForce, ForceMode2D.Impulse);
            StartCoroutine(ShootingTime());
        }
        else if (Input.GetKeyDown("s") && !isshooting)
        {
            isshooting = true;
            GameObject bullet = Instantiate(bulletPrefab, firePointDown.position, firePointDown.rotation);
            if (bullet.GetComponent<Bullet>() != null)
            {
                bullet.GetComponent<Bullet>().Dmg = degats;
                bullet.GetComponent<Bullet>().lifetime = Portee;
            }
            Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();
            rbb.AddForce(firePointDown.up * bulletForce, ForceMode2D.Impulse);
            StartCoroutine(ShootingTime());
        }
        else if (Input.GetKeyDown("z") && !isshooting)
        {
            isshooting = true;
            GameObject bullet = Instantiate(bulletPrefab, firePointUp.position, firePointUp.rotation);
            if (bullet.GetComponent<Bullet>() != null)
            {
                bullet.GetComponent<Bullet>().Dmg = degats;
                bullet.GetComponent<Bullet>().lifetime = Portee;
            }
            Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();
            rbb.AddForce(firePointUp.up * bulletForce, ForceMode2D.Impulse);
            StartCoroutine(ShootingTime());
        }

    }

    private IEnumerator ShootingTime()
    {
      
                yield return atkDelaiDuration;
              
                    isshooting = false;
               
            

           
        
    }
}

