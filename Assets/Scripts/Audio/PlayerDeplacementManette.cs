using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeplacementManette : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement du joueur
    public SpriteRenderer render;
    public SoundManager sm;
    private Rigidbody2D rbp;
    public Sprite[] sprites;
    public bool turnedLeft = false;
    private float horizontal, vertical;
    public float AtkSpeed = 1f;
    public Animator anim;

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
        Animation();
        sm.PlaySFX(SfxType.SFX1);
        Vector2 movement = new Vector2(horizontal, vertical); // Crée un vecteur de mouvement en fonction des inputs
        rbp.velocity = movement * speed; // Déplace le joueur en fonction du vecteur de mouvement et de la vitesse
    }


        public void Animation()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            anim.SetFloat("Right", horizontal);
            anim.SetFloat("Left", -horizontal);
            anim.SetFloat("Up", vertical);
            anim.SetFloat("Down", -vertical);
        }

}
