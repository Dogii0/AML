using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public double damage = 0.5;
    public PlayerHealth playerHealth;

    private void OnCollisionEnter2D(Collision2D collission)
    {
        if (collission.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }
    
}
