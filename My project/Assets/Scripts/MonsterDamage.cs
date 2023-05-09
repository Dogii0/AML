using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public double damage = 0.5;
    public PlayerHealth playerHealth;
    public float time = 2;
    public bool touch;


    private void OnCollisionEnter2D(Collision2D Collission)
    {
        if (Collission.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);

        }

    }
}



