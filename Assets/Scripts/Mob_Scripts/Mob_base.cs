using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_base : EnemyScript
{
    public float horizontal;
    public float vertical;
    public SpriteRenderer render;
    public bool turnedLeft = false;


    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        int rnd = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[rnd];
        target = GameObject.Find("Player").transform;
        Debug.Log(target.name);
        setspeed(1f);
        setHealth(2f);
    }

    // Update is called once per frame
    void Update()
    {
        IaMob();

        horizontal = target.position.x - transform.position.x;
        vertical = target.position.y - transform.position.y;

        turnedLeft = false;
        if (horizontal > 0 && Mathf.Abs(vertical)< Mathf.Abs(horizontal))
        {
            // GetComponent<Animator>().Play("Right");
            render.sprite = sprites[0];

        }
        else if (horizontal < 0 && Mathf.Abs(vertical) < Mathf.Abs(horizontal))
        {
            // GetComponent<Animator>().Play("Left");
            render.sprite = sprites[1];
            turnedLeft = true;
        }
        else if (vertical > 0 && Mathf.Abs(horizontal) < Mathf.Abs(vertical))
        {
            // GetComponent<Animator>().Play("Up");
            render.sprite = sprites[2];
        }
        else if (vertical < 0 && Mathf.Abs(horizontal) < Mathf.Abs(vertical))
        {
            render.sprite = sprites[3];
            // GetComponent<Animator>().Play("Down");
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
