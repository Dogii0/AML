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
    public float Hitpoints;
    public float max_HP;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        Healthbarboss.SetHealth(Hitpoints, max_HP);
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);
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

    public void hit(float damage)
    {
        Hitpoints -= damage;

        if (Hitpoints == 0)
        {
            Destroy(gameObject);
        }
    }
    
}
