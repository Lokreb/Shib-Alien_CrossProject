using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeplacementManette : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement du joueur
    public SpriteRenderer render;
    private Rigidbody2D rbp;
    public Sprite[] sprites;
    private bool isshooting = false;

    public bool turnedLeft = false;
    private float horizontal, vertical;
    public float AtkSpeed = 1f;

    private WaitForSeconds atkDelaiDuration;

    void Start()
    {
        rbp = GetComponent<Rigidbody2D>(); // Récupère le composant Rigidbody2D
        atkDelaiDuration = new WaitForSeconds(1/AtkSpeed);
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // Récupère l'input horizontal de la manette
        float vertical = Input.GetAxisRaw("Vertical"); // Récupère l'input vertical de la manette
        rbp.velocity = new Vector2(horizontal * speed, vertical * speed);
        turnedLeft = false;
        shootingEye();
        Vector2 movement = new Vector2(horizontal, vertical); // Crée un vecteur de mouvement en fonction des inputs

        rbp.velocity = movement * speed; // Déplace le joueur en fonction du vecteur de mouvement et de la vitesse
    }


    public void shootingEye()
    {

        if (isshooting)
        {
            GetComponent<Animator>().enabled = true;

            if (Input.GetKeyDown("d"))
            {
                GetComponent<Animator>().Play("PersoAttaqueDroite");
            }
            else if (Input.GetKeyDown("q"))
            { 
                GetComponent<Animator>().Play("PersoAttaqueGauche");
            }
            else if (Input.GetKeyDown("z"))
            { 
                GetComponent<Animator>().Play("PersoAttaqueDerriere");
            }
            else if (Input.GetKeyDown("s"))
            {
                GetComponent<Animator>().Play("PersoAttaqueDevant");
            }
        }
        else if (!isshooting)
        {
            GetComponent<Animator>().enabled = true;
            if (horizontal > 0)
            {
                GetComponent<Animator>().Play("PersoDeplacementDroite");
                //render.sprite = sprites[0];
            }
            else if (horizontal < 0)
            {
                GetComponent<Animator>().Play("PersoDeplacementGauche");
                //render.sprite = sprites[1];
                turnedLeft = true;
            }
            else if (vertical > 0)
            {
                GetComponent<Animator>().Play("PersoDeplacementDerriere");
                //render.sprite = sprites[2];
            }
            else if (vertical < 0)
            {
                //render.sprite = sprites[3];
                GetComponent<Animator>().Play("PersoDeplacementDevant");
            }
        }



    }


}
