using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public double Max_Health = 10;
    public double health;
    public HealthBar healthbar;
    private GameObject player;
    void Start()
    {
        health = Max_Health;
        healthbar.SetMaxHealth(Max_Health);
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void TakeDamage(double damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(player);
        }
        healthbar.SetHealth(health);
    }
    public void Heal(double hp)
    {
        Debug.Log(health + "heallllling" + hp);
        health += hp;
        if (health >= Max_Health)
        {
            health = Max_Health;
            return;
        }
        healthbar.SetHealth(health);
    }
    
}
