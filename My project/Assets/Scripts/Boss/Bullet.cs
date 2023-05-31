using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{ 
    public GameObject player;
    private Rigidbody2D rb;
    public PlayerHealth playerHealth;
    public float force;
    private float timer;
    public double damage = 0.5;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (gameObject.name == "BossAttack(Clone)")
        {
            if (timer > 5)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == player)
        {
            if (gameObject.name == "BossAttack(Clone)")
            {
                Destroy(gameObject);
            }
            playerHealth.TakeDamage(damage);
        }    
        
    }
}
