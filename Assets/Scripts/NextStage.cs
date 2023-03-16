using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStage : MonoBehaviour
{
    public GameObject LoadingScreen;

   public GameManager GM;
    public RandomRoom RR;
    public GameObject NS;
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
        if (collision.gameObject.CompareTag("Player") && GM.clear == true)
        {
            LoadingScreen.SetActive(true);

            GoNext();

            NS.SetActive(false);
        }
    }


    public void GoNext()
    {

       
        GM.player.SetActive(false);
        SpawnerScript.AllKilled = false;
        SpawnerScript.IsFinish = false;
        GM.clear = false;
        if (RandomRoom.GoBoss == false)
        {
            RR.SelectARoom();

        }
        else if (RandomRoom.GoBoss == true)
        {
            RR.SelectBoss();
        }
        
        GM.player.SetActive(true);
        GM.ReplacePlayer();
         LoadingScreen.SetActive(false);
    }
}
