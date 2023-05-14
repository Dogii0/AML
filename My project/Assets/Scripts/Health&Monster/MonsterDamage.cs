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
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        // playerHealth = player;
    }

    private void OnCollisionStay2D(Collision2D Collission)
    {
        if (Collission.gameObject == player)
        {
            playerHealth.TakeDamage(damage);

        }

    }
}



