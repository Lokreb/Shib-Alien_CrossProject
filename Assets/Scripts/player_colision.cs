using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_colision : MonoBehaviour
{
    public GameManager GM;
   [SerializeField] PlayerMovement pm;
    public int LifePoint = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LifePoint <= 0)
        {
           
            GM.GameOver();
            dead();
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mob"))
        {
            LifePoint = LifePoint - 1;
        }
    }

    public void dead()
    {
        pm.IsAlive = false;
    }
}
