using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Tank : EnemyScript
{
    public float horizontal;
    public float vertical;
    public SpriteRenderer render;
    public bool turnedLeft = false;


    // Start is called before the first frame update
    private void Start()
    {
        base.Start();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        int rnd = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[rnd];
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        Debug.Log(target.name);
        setspeed(1f);
        setHealth(10f);
    }

    // Update is called once per frame
    void Update()
    {
       // IaMob();

        horizontal = target.position.x - transform.position.x;
        vertical = target.position.y - transform.position.y;

        turnedLeft = false;
        if (horizontal > 0 && Mathf.Abs(vertical)< Mathf.Abs(horizontal))
        {
            GetComponent<Animator>().Play("TankMarcheDroite");
            //render.sprite = sprites[0];

        }
        else if (horizontal < 0 && Mathf.Abs(vertical) < Mathf.Abs(horizontal))
        {
            GetComponent<Animator>().Play("TankMarcheGauche");
            //render.sprite = sprites[1];
            turnedLeft = true;
        }
        else if (vertical > 0 && Mathf.Abs(horizontal) < Mathf.Abs(vertical))
        {
            GetComponent<Animator>().Play("TankMarcheDerriere");
            //render.sprite = sprites[2];
        }
        else if (vertical < 0 && Mathf.Abs(horizontal) < Mathf.Abs(vertical))
        {
            //render.sprite = sprites[3];
            GetComponent<Animator>().Play("TankMarcheDevant");
        }
       
    }
   override protected void IaMob()
    {
        range = Vector2.Distance(transform.position, target.position);
        if (range < minDistance && !isDead)
        {
            if (!targetCollision)
            {
                // Get the position of the player
                transform.LookAt(target.position);

                // Correct the rotation
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
        }
        transform.rotation = Quaternion.identity;
    }
}
