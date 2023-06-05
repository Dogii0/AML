using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    // public Transform playerTransform;
    public bool isChasing;
    private Transform playerTransform;
    public float ChaseDistance;
    private float distance;

    public void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
    }

    void Update()
    {
        if (isChasing)
        {
            distance = Vector2.Distance(transform.position, playerTransform.position);
            Vector2 direction = playerTransform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (distance < ChaseDistance)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, playerTransform.position,
                    moveSpeed * Time.deltaTime);
                if(playerTransform.position.x < transform.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                if(playerTransform.position.x > transform.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                

            }
            else
            {
                isChasing = false;
                if (patrolDestination == 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }

            }
            
        }
        else
        {
            if (Vector2.Distance(transform.position, playerTransform.position) < ChaseDistance)
            {
                isChasing = true;
            }
            if (patrolDestination == 0)
            {
                transform.position =
                    Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < 0.2f)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    patrolDestination = 1;
                }
            }
        
            if (patrolDestination == 1)
            {
                transform.position =
                    Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < 0.2f)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    patrolDestination = 0;
                }
            }
        }
        
    }


}
