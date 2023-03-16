using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

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
    public float fightDuration = 45f;
    private float timeRemaining= 1f;
    public TMP_Text timerText;
    public GameObject timerTextObject;
    public bool clear;
    public bool BossEnd = false;
    public bool isIn = false;
    public bool bossStart = false;
    public GameObject[] fairy;
   

    private Scene scene;

    void Start()
    {
        timerTextObject.SetActive(false);
    }

    private void Update()
    {
        if ( SpawnerScript.AllKilled == true && SpawnerScript.IsFinish == true)
        {
            clear = true;
            NS.SetActive(true);
        }
        //Debug.Log(RandomRoom.timerBoss);


        if (RandomRoom.timerBoss == true)
        {
            BossMode();
        }

        // Check if the fight is over
        if (timeRemaining == 0f && BossEnd == true)
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
        // Start the timer
        if(bossStart == false)
        {
            timeRemaining = fightDuration;
            bossStart = true;
        }
        
        Debug.Log(timeRemaining);
        // Update the text of the UI element to display the remaining time in seconds
        
        timerText.text = $"{Mathf.CeilToInt(timeRemaining)}";
        timeRemaining -= Time.deltaTime;
        UpdateTimerDisplay();
        timerTextObject.SetActive(true);
        fairy[0].SetActive(false);
        fairy[1].SetActive(true);
        //timeRemaining -= Time.deltaTime;
        isIn = true;

    }

    private void UpdateTimerDisplay()
    {
        if (timeRemaining <= 0f)
        {
            // Stop the timer
            timeRemaining = 0f;
            timerText.text = "0";
            timerTextObject.SetActive(false);
            RandomRoom.timerBoss = false;
            BossEnd = true;
            fairy[1].SetActive(false);
            fairy[0].SetActive(true);
            return;
        }
    }
}
