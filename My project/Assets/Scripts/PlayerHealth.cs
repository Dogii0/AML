using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public double Max_Health = 10;
    public double health;
    // Start is called before the first frame update
    void Start()
    {
        health = Max_Health;
    }

    public void TakeDamage(double damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
