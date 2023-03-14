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
            Debug.Log($"Player picked up {bonusName} bonus!");
            Destroy(gameObject);
        }
    }
}
