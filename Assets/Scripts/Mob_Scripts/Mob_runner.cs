using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_runner : EnemyScript
{

    
    float initialspeed = 0;
    float maxspeed = 0;
    public float acceleration = 1f;
     
    // public float accelerationInterval = 5f;
    public float accelerationIntervalRange = 5f;
    public float accelerationDurationRange = 5f;
    public float stopDurationRange = 1f;
    private bool isAccelerating = false; // détermine si le monstre est déjà en train d'accélérer
    private WaitForSeconds accelerationWait; // l'objet Wait pour attendre l'intervalle de temps entre chaque accélération
    private WaitForSeconds accelerationDuration;
    private WaitForSeconds stopDuration;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        int rnd = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[rnd];
        target = GameObject.Find("Player").transform;
        Debug.Log(target.name);

        setspeed(1.3f);
        setHealth(4f);
        initialspeed = speed;
        stopDurationRange = Random.Range(0.5f, 2f);
        accelerationIntervalRange = Random.Range(4f, 10f);
        accelerationDurationRange = Random.Range(4f, 6f);
        accelerationWait = new WaitForSeconds(accelerationIntervalRange);
        accelerationDuration = new WaitForSeconds(accelerationDurationRange);
        stopDuration = new WaitForSeconds(stopDurationRange);
        StartCoroutine(AccelerateMonster());

    }

    // Update is called once per frame
    void Update()
    {
        IaMob();
    }

    override protected void IaMob()
    {
       
        if ( !isDead)
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
    }
    private IEnumerator AccelerateMonster()
    {
        while (true)
        {
            if (!isAccelerating)
            {
                acceleration = Random.Range(0.2f, 2f);
                maxspeed = initialspeed + acceleration;
                isAccelerating = true;
                yield return accelerationWait;
                speed = Mathf.Min(initialspeed + acceleration, maxspeed);
                yield return accelerationDuration;
                speed = 0;
                yield return stopDuration;
                speed = initialspeed;
                isAccelerating = false;
                
            }
            yield return null;
        }
    }
}
