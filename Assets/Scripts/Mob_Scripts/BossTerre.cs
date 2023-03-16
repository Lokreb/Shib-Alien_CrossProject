using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTerre : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public SpriteRenderer render;
    public bool turnedLeft = false;
    public Transform firePointDown;
    public GameObject bulletPrefab;
    private bool isshooting = false;
    public float bulletForce = 50f;
    public float AtkSpeed = 1f;
    public float speed = 10f;
    private WaitForSeconds atkDelaiDuration;
    public int degats = 1;
    public float Portee = 1f;
    public Transform target;
    protected GameManager gameManager;
    public Sprite[] sprites;


    // Start is called before the first frame update
    private void Start()
    {
      
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //int rnd = Random.Range(0, sprites.Length);
        //GetComponent<SpriteRenderer>().sprite = sprites[rnd];
        atkDelaiDuration = new WaitForSeconds(1 / AtkSpeed);
        Debug.Log(target.name);
    }

    // Update is called once per frame
    void Update()
    {
        IaBoss();

        horizontal = target.position.x - transform.position.x;
        vertical = target.position.y - transform.position.y;

    }
     protected void IaBoss()
    {
        Vector3 currentPosition = transform.position;

        // Only update the x-coordinate of the boss's position
        currentPosition.x = Mathf.MoveTowards(currentPosition.x, target.position.x, speed * Time.deltaTime);

        // Update the boss's position to follow the player on the x-axis only
        transform.position = currentPosition;
        shootOrNot();

    }

    public void ShootingDown()
    {
        GameObject bullet4 = Instantiate(bulletPrefab, firePointDown.position, firePointDown.rotation);
        Rigidbody2D rbb = bullet4.GetComponent<Rigidbody2D>();
        rbb.AddForce(firePointDown.up * bulletForce, ForceMode2D.Impulse);
        Debug.Log(bulletForce);

    }



    public void shootOrNot()
    {

        horizontal = target.position.x - transform.position.x;
        vertical = target.position.y - transform.position.y;

        if (vertical < 0 && Mathf.Abs(horizontal) < Mathf.Abs(vertical) && !isshooting)
        {
            //render.sprite = sprites[3];
            // GetComponent<Animator>().Play("Down");
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
    }

    private IEnumerator ShootingTimeM()
    {

        yield return atkDelaiDuration;

        isshooting = false;





    }
}
