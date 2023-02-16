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
                    player.atkspeed += bonus[0].increase;
                    break;
                case "projectilespeed":
                    player.projectilespeed += bonus[1].increase;
                    break;
                case "speed":
                    player.speed += bonus[2].increase;
                    break;
                case "projectile":
                    player.projectile += bonus[3].increase;
                    break;
                case "pattern":
                    player.pattern.Add("new pattern"); // add the new pattern
                    break;
                    case "damage":
                    player.degats += bonus[5].increase;
                    break;
                case "rebond":
                    player.rebond += bonus[6].increase;
                    break;
                default:
                    break;
            }

            // Remove the bonus object from the game
            Destroy(gameObject);
        }
    }
}
