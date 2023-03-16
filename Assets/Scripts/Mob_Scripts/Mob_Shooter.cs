using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Shooter : EnemyScript
{
    public float horizontal;
    public float vertical;
    public SpriteRenderer render;
    public bool turnedLeft = false;
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


    // Start is called before the first frame update
    private void Start()
    {
        base.Start();
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        int rnd = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[rnd];
        atkDelaiDuration = new WaitForSeconds(1 / AtkSpeed);
        Debug.Log(target.name);
        setspeed(1.1f);
        setHealth(3f);
    }

    // Update is called once per frame
    void Update()
    {
        IaMob();

        horizontal = target.position.x - transform.position.x;
        vertical = target.position.y - transform.position.y;
       
    }
   override protected void IaMob()
    {
        shootOrNot();

    }
    public void ShootingRight()
    {   
        GetComponent<Animator>().Play("AttaqueSqueletteDroite");
        GameObject bullet1 = Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);
        if (bullet1.GetComponent<Bullet>() != null)
        {
            bullet1.GetComponent<Bullet>().Dmg = degats;
        }
        Rigidbody2D rbb = bullet1.GetComponent<Rigidbody2D>();
        rbb.AddForce(firePointLeft.up * bulletForce, ForceMode2D.Impulse);

    }

    public void ShootingLeft()
    {
        GetComponent<Animator>().Play("AttaqueSqueletteGauche");
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
        GetComponent<Animator>().Play("AttaqueSqueletteDevant");
        GameObject bullet3 = Instantiate(bulletPrefab, firePointUp.position, firePointUp.rotation);
        Rigidbody2D rbb = bullet3.GetComponent<Rigidbody2D>();
        rbb.AddForce(firePointUp.up * bulletForce, ForceMode2D.Impulse);

    }

    public void ShootingDown()
    {
        GetComponent<Animator>().Play("AttaqueSqueletteDerriere");
        GameObject bullet4 = Instantiate(bulletPrefab, firePointDown.position, firePointDown.rotation);
        Rigidbody2D rbb = bullet4.GetComponent<Rigidbody2D>();
        rbb.AddForce(firePointDown.up * bulletForce, ForceMode2D.Impulse);
        Debug.Log(bulletForce);

    }



    public void shootOrNot()
    {

        horizontal = target.position.x - transform.position.x;
        vertical = target.position.y - transform.position.y;

        if (horizontal > 0 && Mathf.Abs(vertical) < Mathf.Abs(horizontal) && !isshooting)
        {   GetComponent<Animator>().Play("AnimSqueletteDroite");
            //render.sprite = sprites[0];

            isshooting = true;
            GameObject bullet = Instantiate(bulletPrefab, firePointRight.position, firePointRight.rotation);
            if (bullet.GetComponent<Bullet>() != null)
            {
                bullet.GetComponent<Bullet>().Dmg = degats;
                bullet.GetComponent<Bullet>().lifetime = Portee;
            }
            Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();
            rbb.AddForce(firePointRight.up * bulletForce, ForceMode2D.Impulse);
            StartCoroutine(ShootingTimeM());
        }
        else if (horizontal < 0 && Mathf.Abs(vertical) < Mathf.Abs(horizontal) && !isshooting)
        {   GetComponent<Animator>().Play("AnimSqueletteGauche");
            //render.sprite = sprites[1];

            isshooting = true;
            GameObject bullet = Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);

            if (bullet.GetComponent<Bullet>() != null)
            {
                bullet.GetComponent<Bullet>().Dmg = degats;
                bullet.GetComponent<Bullet>().lifetime = Portee;
            }
            Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();
            rbb.AddForce(firePointLeft.up * bulletForce, ForceMode2D.Impulse);
            StartCoroutine(ShootingTimeM());
        }
        else if (vertical > 0 && Mathf.Abs(horizontal) < Mathf.Abs(vertical) && !isshooting)
        {
            GetComponent<Animator>().Play("AnimSqueletteDerriere");
            //render.sprite = sprites[2];

            isshooting = true;
            GameObject bullet = Instantiate(bulletPrefab, firePointDown.position, firePointDown.rotation);
            if (bullet.GetComponent<Bullet>() != null)
            {
                bullet.GetComponent<Bullet>().Dmg = degats;
                bullet.GetComponent<Bullet>().lifetime = Portee;
            }
            Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();
            rbb.AddForce(firePointDown.up * bulletForce, ForceMode2D.Impulse);
            StartCoroutine(ShootingTimeM());
        }
        else if (vertical < 0 && Mathf.Abs(horizontal) < Mathf.Abs(vertical) && !isshooting)
        {
            //render.sprite = sprites[3];
            GetComponent<Animator>().Play("AnimSqueletteDevant");
            isshooting = true;
            GameObject bullet = Instantiate(bulletPrefab, firePointUp.position, firePointUp.rotation);
            if (bullet.GetComponent<Bullet>() != null)
            {
                bullet.GetComponent<Bullet>().Dmg = degats;
                bullet.GetComponent<Bullet>().lifetime = Portee;
            }
            Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();
            rbb.AddForce(firePointUp.up * bulletForce, ForceMode2D.Impulse);
            StartCoroutine(ShootingTimeM());
        }

    }

    private IEnumerator ShootingTimeM()
    {

        yield return atkDelaiDuration;

        isshooting = false;





    }


}
