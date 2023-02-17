using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBase : EnemyScript2
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
        setspeed2(1f);
        setHealth2(2f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
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
}
