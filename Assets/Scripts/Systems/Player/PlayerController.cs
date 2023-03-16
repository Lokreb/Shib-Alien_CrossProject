using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private JSONReader.Player player;
    void Start()
    {
        Invoke("PlayerStats", 0.1f); 
    }

    private void PlayerStats() {
        player = JSONReader.Instance.GetStats();
        Debug.Log(player.nom);
        Debug.Log(player.pv);
        Debug.Log(player.damage);
        Debug.Log(player.atkspeed);
        Debug.Log(player.projectilespeed);
        Debug.Log(player.speed);
        Debug.Log(player.projectile);
        Debug.Log(player.pattern);
        Debug.Log(player.rebond);
    }
}
