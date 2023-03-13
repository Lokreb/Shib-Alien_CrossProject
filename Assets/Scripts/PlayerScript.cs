using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float speed = 4.0f;
    Rigidbody2D rb;

    private float health = 200;
    private float startHealth;

    public bool turnedLeft = false;
    public Image healthFill;
    private float healthWidth;
    public Text mainText;
    public Image redOverlay;
    public Text expText;

    private int experience = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthWidth = healthFill.sprite.rect.width;
        startHealth = health;
        mainText.gameObject.SetActive(true);
        redOverlay.gameObject.SetActive(true);
        Invoke("HideTitle", 2);
    }

    // Update is called once per frame
    void Update()
    {
        checklife();
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        turnedLeft = false;
        if (horizontal > 0)
        {
            GetComponent<Animator>().Play("Right");
        } else if (horizontal < 0)
        {
            GetComponent<Animator>().Play("Left");
            turnedLeft = true;
        } else if (vertical > 0)
        {
            GetComponent<Animator>().Play("Up");
        } else if (vertical < 0)
        {
            GetComponent<Animator>().Play("Down");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            getHited();
          
         //   Vector2 temp = new Vector2(healthWidth * (health / startHealth), healthFill.sprite.rect.height);
          //  healthFill.rectTransform.sizeDelta = temp;
           
        }
  
}

    void HidePlayerBlood()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void GainExperience(int amount)
    {
        experience += amount;
        expText.text = experience.ToString();
    }

    void HideTitle()
    {
        mainText.gameObject.SetActive(false);
        redOverlay.gameObject.SetActive(false);
    }

    public void checklife()
    {
        if (health < 1)
        {
            healthFill.enabled = false;
            mainText.gameObject.SetActive(true);
            mainText.text = "Game Over";
            redOverlay.gameObject.SetActive(true);
        }
   }
    public void getHited()
    {
        health = health - 1;
    }
}
