using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_colision : MonoBehaviour
{

    public int LifePoint = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mob"))
        {
            LifePoint = LifePoint - 1;
        }
    }
}
