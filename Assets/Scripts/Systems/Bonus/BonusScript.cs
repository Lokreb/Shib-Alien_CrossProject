using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    public string bonusName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            JSONReader.Bonus bonus = JSONReader.Instance.GetRandomBonus(); // get a random bonus
            Debug.Log($"Player picked up {bonus.nom} bonus!"); // log the value of the bonus
            Destroy(gameObject); // destroy the bonus object
        }
    }
}
