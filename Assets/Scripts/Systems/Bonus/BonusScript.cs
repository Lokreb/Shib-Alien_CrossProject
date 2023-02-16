using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    public JSONReader.Player player; // Reference to the player's stats
    public JSONReader.Bonus bonus; // Reference to the bonus data

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Apply the bonus effects to the player
            switch (bonus.nom)
            {
                case "atkspeed":
                    player.atkspeed += bonus.increase;
                    break;
                case "projectilespeed":
                    player.projectilespeed += bonus.increase;
                    break;
                case "speed":
                    player.speed += bonus.increase;
                    break;
                case "projectile":
                    player.projectile += bonus.valeur;
                    break;
                case "pattern":
                    player.pattern.Add("new pattern"); // add the new pattern
                    break;
                    case "damage":
                    player.degats += bonus.valeur;
                    break;
                case "rebond":
                    player.rebond += bonus.valeur;
                    break;
                default:
                    break;
            }

            // Remove the bonus object from the game
            Destroy(gameObject);
        }
    }
}
