using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_mob : MonoBehaviour
{
    //public GameObject hitEffect; //pour ajouter une animation d explosion
    Rigidbody2D rb;
    public int Dmg;
    public float lifetime = 2f;
    public WaitForSeconds Range;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Range = new WaitForSeconds(lifetime);
        StartCoroutine(RangeOfBullet());
    }


    private void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //GameObject effect = (Instantiate(hitEffect, transform.position, Quaternion.identity));
        //Destroy(effect, 5f);
        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag == "Player" && collision.gameObject.tag != "Mob")
        {
           
                Debug.Log("pattepatte22222222222222");
                collision.gameObject.GetComponent<player_colision>().getHited();
                Destroy(gameObject);
            
        }
        else if (collision.gameObject.tag == "Wall")
        {

            rb.velocity = Vector2.zero;
            Destroy(gameObject);
        }
        Debug.Log(collision.gameObject);
    }

    private IEnumerator RangeOfBullet()
    {
        
        yield return Range;
        Destroy(gameObject);





    }
}