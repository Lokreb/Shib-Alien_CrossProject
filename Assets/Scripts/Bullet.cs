using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject hitEffect; //pour ajouter une animation d explosion

    void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect = (Instantiate(hitEffect, transform.position, Quaternion.identity));
        //Destroy(effect, 5f);
        if(collision.gameObject.tag!="Bullet" && collision.gameObject.tag!="Player" )
        {
            Destroy(gameObject);
        }

    }


}