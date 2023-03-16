using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_colision : MonoBehaviour
{
    public GameManager GM;
   [SerializeField] PlayerMovement pm;
    public int LifePoint = 3;
    public GameObject[] UiCoeur;
    int it;
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
            for (it = 0; it < UiCoeur.Length; it++)
            {
                UiCoeur[it].SetActive(false);
            }
            UiCoeur[0].SetActive(true);
        }

        if(LifePoint == 1)
        {
            for(it = 0; it < UiCoeur.Length; it++)
            {
                UiCoeur[it].SetActive(false);
            }
            UiCoeur[1].SetActive(true);
        }
        else if (LifePoint == 2)
        {
            for (it = 0; it < UiCoeur.Length; it++)
            {
                UiCoeur[it].SetActive(false);
            }
            UiCoeur[2].SetActive(true);
        }
        if (LifePoint == 3)
        {
            for (it = 0; it < UiCoeur.Length; it++)
            {
                UiCoeur[it].SetActive(false);
            }
            UiCoeur[3].SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mob"))
        {
            getHited();
        }
    }

    public void dead()
    {
        pm.IsAlive = false;
    }
    public void checklife()
    {
        if (LifePoint < 1)
        {
            dead();


        }
    }
    public void getHited()
    {
        LifePoint = LifePoint - 1;
    }
}
