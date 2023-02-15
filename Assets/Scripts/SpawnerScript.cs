using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class SpawnerScript : MonoBehaviour
{
    // public GameObject enemyPrefab;
    public Tilemap spawnPoints;
    private float timer;
    public Sprite deathSprite;
    public Sprite gateway;
    //public Tilemap tileMap = null;

    public Sprite weaponUpgrade;

    public int Number_Mob = 5;
    public GameObject[] enemyPrefab;
    public List<Vector3> availablePlaces;
    private GameManager gameManager;
    int rnd;
    int spawned_mob;
    static int Actual_Mob;
    int rndPlace;
    public int MaxWaves = 2;
    int actualWave = 0;
    static public bool IsFinish = false;
    static public bool AllKilled = false;


    void Start()
    {
        actualWave =0;
        IsFinish = false;
        AllKilled = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //  Instantiate(enemyPrefab, spawnPoints[0].transform.position, Quaternion.identity);
        // Instantiate(enemyPrefab, spawnPoints[1].transform.position, Quaternion.identity);
        timer = Time.time + 5.0f;
        rnd = Random.Range(0, enemyPrefab.Length);
        //  GetComponent<SpriteRenderer>().sprite = Number_Mob[rnd];


        //spawnPoints = transform.GetComponent<Tilemap>();
        availablePlaces = new List<Vector3>();

        for (int n = spawnPoints.cellBounds.xMin; n < spawnPoints.cellBounds.xMax; n++)
        {
            for (int p = spawnPoints.cellBounds.yMin; p < spawnPoints.cellBounds.yMax; p++)
            {
                Vector3Int localPlace = new Vector3Int(n, p, (int)spawnPoints.transform.position.y);
                Vector3 place = spawnPoints.GetCellCenterWorld(localPlace);
                if (spawnPoints.HasTile(localPlace))
                {
                    //Tile at "place"
                    availablePlaces.Add(place);
                }
                else
                {
                    //No tile at "place"
                }
            }
        }
        rndPlace = Random.Range(0, availablePlaces.Count);
    }


    void Update()
    {

        if (actualWave < MaxWaves)
        {
            for (int j = 0; j <= MaxWaves; j++)
            {
                if (timer < Time.time && spawned_mob < Number_Mob)
                {


                    for (int i = 0; i < Number_Mob; i++)
                    {
                        // GetComponent<SpriteRenderer>().sprite = Number_Mob[rnd];
                        Instantiate(enemyPrefab[rnd], availablePlaces[rndPlace], Quaternion.identity);
                        availablePlaces.RemoveAt(rndPlace);
                        rnd = Random.Range(0, enemyPrefab.Length);
                        rndPlace = Random.Range(0, availablePlaces.Count);
                        Actual_Mob++;
                        spawned_mob++;
                    }

                    // Instantiate(enemyPrefab, spawnPoints[spawnIndex % 2].transform.position, Quaternion.identity);
                    timer = Time.time + 7.0f;



                }
                spawned_mob = 0;
                actualWave++;
            }
        }
       else if (actualWave == MaxWaves)
        { 
            IsFinish = true;

            if (Actual_Mob == 0)
            {
                AllKilled = true;
            }
        }
        
    }

    public static void actualise_mob()
    {
        Actual_Mob = Actual_Mob - 1;
    }

    /*  public void TakeDamage(float amount)
      {
          if (GetComponent<SpriteRenderer>().sprite != gateway)
          {
              health -= amount;
              GetComponent<SpriteRenderer>().color = Color.red;
              if (health < 0)
              {
                  GetComponent<SpriteRenderer>().sprite = deathSprite;
                  if (isGateway)
                  {
                      Invoke("OpenGateway", 0.5f);
                  }
                  else if (isWeaponUpgrade)
                  {
                      Invoke("OpenWeapon", 0.5f);
                  } else
                  {
                      Invoke("DestroySpawner", 0.6f);
                  }

              }
              Invoke("DefaultColor", 0.3f);
          }
      }*/
   
}

