using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    public Sprite speedBonusSprite;
    public Sprite atkSpeedBonusSprite;
    public Sprite projSpeedBonusSprite;
    public Sprite damageBonusSprite;
    public Sprite projectileBonusSprite;
    public Sprite patternBonusSprite;
    public Sprite rebondBonusSprite;
    public Sprite laserBonusSprite;
    public Sprite mineBonusSprite;

    private JSONReader.Bonus bonus;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        // Get a random bonus from the JSONReader
        bonus = JSONReader.Instance.GetRandomBonus();

        // Get the sprite renderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        switch (bonus.nom)
        {
            case "speed":
                spriteRenderer.sprite = speedBonusSprite;
                break;
            case "atkspeed":
                spriteRenderer.sprite = atkSpeedBonusSprite;
                break;
            case "projectilespeed":
                spriteRenderer.sprite = projSpeedBonusSprite;
                break;
            case "damage":
                spriteRenderer.sprite = damageBonusSprite;
                break;
            case "projectile":
                spriteRenderer.sprite = projectileBonusSprite;
                break;
            case "pattern":
                spriteRenderer.sprite = patternBonusSprite;
                break;
            case "rebond":
                spriteRenderer.sprite = rebondBonusSprite;
                break;
            case "laser":
                spriteRenderer.sprite = laserBonusSprite;
                break;
            case "mines":
                spriteRenderer.sprite = mineBonusSprite;
                break;
            default:
                Debug.LogWarning($"Unknown bonus name: {bonus.nom}");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"Player picked up {bonus.nom} bonus!"); // log the value of the bonus

            switch (bonus.nom)
            {
                case "speed":
                    JSONReader.Instance.joueur.speed += bonus.increase;
                    Debug.Log("I am speed!");
                    Debug.Log(JSONReader.Instance.joueur.speed);
                    break;
                case "atkspeed":
                    JSONReader.Instance.joueur.atkspeed += bonus.increase;
                    Debug.Log("I am atkspeed!");
                    Debug.Log(JSONReader.Instance.joueur.atkspeed);
                    break;
                case "projectilespeed":
                    JSONReader.Instance.joueur.projectilespeed += bonus.increase;
                    Debug.Log("I am projspeed!");
                    Debug.Log(JSONReader.Instance.joueur.projectilespeed);
                    break;
                case "degats":
                    JSONReader.Instance.joueur.damage += bonus.valeur;
                    Debug.Log("I am dmg!");
                    Debug.Log(JSONReader.Instance.joueur.damage);
                    break;
                case "projectile":
                    JSONReader.Instance.joueur.projectile += bonus.valeur;
                    Debug.Log("I am proj!");
                    Debug.Log(JSONReader.Instance.joueur.projectile);
                    break;
                case "rebond":
                    JSONReader.Instance.joueur.rebond += bonus.valeur;
                    Debug.Log("I am rebond!");
                    Debug.Log(JSONReader.Instance.joueur.rebond);
                    break;
                case "pattern":
                    Debug.Log("Change shoot!");
                    break;
                case "laser":
                    Debug.Log("Lasabeamu!");
                    break;
                case "mines":
                    Debug.Log("Flashback from 39-45!");
                    break;
                default:
                    Debug.LogWarning($"Unknown bonus name: {bonus.nom}");
                    break;
            }
            Destroy(gameObject); // destroy the bonus object
        }
    }
}
