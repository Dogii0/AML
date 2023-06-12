using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Boss_Script : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletpos;
    private float timer;
    public GameObject player;
    public HealthBarBoss Healthbarboss;
    public double Max_Health = 5;
    public double health;
    public double damage = 0;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        health = Max_Health;
        Healthbarboss.SetHealthmax(Max_Health);
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 6.5)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                shoot();
            }
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletpos.position, Quaternion.identity);
    }

    public void TakeDamage(double damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        Healthbarboss.SetHealthboss(health);
    }
    
    private void OnCollisionStay2D(Collision2D Collission)
    {
        if (Collission.gameObject == player && Input.GetKeyDown(KeyCode.Space))
        {
            if (PlayerMovement.weapon == null)
            {
                Debug.Log("No weapon. Go pick up");
            }
            else
            {
                switch (PlayerMovement.weapon.itemType)
                {
                    case Item.ItemType.FireExt:
                        damage = 1;
                        break;
                    case Item.ItemType.Umbrella:
                        damage = 0.7;
                        break;
                    case Item.ItemType.Tree:
                        damage = 0.5;
                        break;
                    default:
                        damage = 0.3;
                        break;
                }
            }
            Debug.Log("boss got hit");
            TakeDamage(damage);
        }
    }
}
