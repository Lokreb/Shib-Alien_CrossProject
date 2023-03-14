using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bonus"))
        {
            BonusScript bonusScript = collision.GetComponent<BonusScript>();
            JSONReader.Bonus bonus = JSONReader.Instance.GetRandomBonus(); // get a random bonus
            bonusScript.bonusName = bonus.nom; // set the name of the bonus in the BonusController
            Debug.Log($"Player picked up {bonus.nom} bonus!"); // log the name of the bonus
        }
    }
}
