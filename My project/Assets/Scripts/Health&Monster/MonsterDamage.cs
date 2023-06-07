using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterDamage : MonoBehaviour
{
    public double damage = 0.5;
    private GameObject player;
    public PlayerHealth playerHealth;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void OnCollisionStay2D(Collision2D Collission)
    {
        if (Collission.gameObject == player)
        {
            Debug.Log("collide with Monster");
            playerHealth.TakeDamage(damage);
        }
    }
}



