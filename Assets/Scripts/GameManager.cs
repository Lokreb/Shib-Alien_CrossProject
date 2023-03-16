using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject spwan;
   // public GameObject weapon;
    public GameObject hudCanvas;
    public GameObject NS;
    public GameObject BlackScreen;
    public GameObject BlackEndScreen;
    public GameObject Replay;
    public bool clear;
    public bool BossEnd = false;
   

    private Scene scene;

    void Start()
    {
    }

    private void Update()
    {
        
        if( SpawnerScript.AllKilled == true && SpawnerScript.IsFinish == true)
        {
            clear = true;
            NS.SetActive(true);
        }

        if (BossEnd == true)
        {
            GameEnd();
        }
    }

    void Awake()
    {

        //DontDestroyOnLoad(player.gameObject);
  
       DontDestroyOnLoad(gameObject);
        
        scene = SceneManager.GetActiveScene();
    }


     

 public void ReplacePlayer()
    {
        player.transform.position = spwan.transform.position;
    }

    public void GameOver()
    {
        BlackScreen.SetActive(true);
        Replay.SetActive(true);
    }
    public void GameEnd()
    {
        BlackEndScreen.SetActive(true);
       // Replay.SetActive(true);
    }

    public void reloadGame()
    {
        SceneManager.LoadScene(0);
    }

    public void BossMode()
    {

    }
  
}
