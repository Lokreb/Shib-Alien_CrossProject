using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyScript2 : MonoBehaviour  
{
    protected float range;
    public Transform target;
    protected float minDistance = 5.0f;
    protected bool targetCollision = false;
    protected float speed = 1.0f;
    protected float health = 5;
    protected int hitStrength = 10;
    protected float thrust = 1.5f;

    
    public Sprite[] sprites;

    protected GameManager gameManager;

    protected bool isDead = false;
    
    void Start()
    {
       
        
    }



    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collision.collider.bounds.center;

            targetCollision = true;

            bool right = contactPoint.x > center.x;
            bool left = contactPoint.x < center.x;
            bool top = contactPoint.y > center.y;
            bool bottom = contactPoint.y < center.y;

            if (right) GetComponent<Rigidbody2D>().AddForce(transform.right * thrust, ForceMode2D.Impulse);
            if (left) GetComponent<Rigidbody2D>().AddForce(-transform.right * thrust, ForceMode2D.Impulse);
            if (top) GetComponent<Rigidbody2D>().AddForce(transform.up * thrust, ForceMode2D.Impulse);
            if (bottom) GetComponent<Rigidbody2D>().AddForce(-transform.up * thrust, ForceMode2D.Impulse);
            Invoke("FalseCollision", 0.5f);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("bullet");
            TakeDamage2(health);
            Debug.Log(health);
        }        
    }

    void FalseCollision2()
    {
        targetCollision = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    public void TakeDamage_(float amount)
    {
        health -= amount;
        if(health < 0)
        {
            isDead = true;
            SpawnerScript.actualise_mob();
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            
            GetComponent<SpriteRenderer>().sortingOrder = -1;
            GetComponent<Collider2D>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            Invoke("EnemyDeath", 1.5f);
        } else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Invoke("HideBlood", 0.25f);
        }
    }

    void HideBlood2()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    void EnemyDeath2()
    {
       
        Destroy(gameObject);
    }

    public int GetHitStrength2()
    {
        return hitStrength;
    }
    protected virtual void IaMob2()
    { /*
        if (!isDead)
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
        */ 
    }

    public float getHealth2()
    {
        return health;
    }

    public void setHealth2(float newHealth)
    {
        this.health = newHealth;
    }


    public float getspeed2()
    {
        return speed;
    }

    public void setspeed2(float newspeed)
    {
        this.speed = newspeed;
    }

    public void TakeDamage2(float amount)
    {
        health -= amount;
        if(health == 0)
        {
            EnemyDeath2();
        }

}
}

