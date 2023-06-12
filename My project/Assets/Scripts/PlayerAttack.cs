using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    //private GameObject AttackArea = default;
    
    //private bool attacking = false;
    //private float timetoAttack = 0.25f;
    //private float timer = 0f;
    private GameObject player;
    private GameObject boss;
    public Boss_Script Bosshealth;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    
    /*void Start()
    {
        AttackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timetoAttack)
            {
                timer = 0;
                attacking = false;
                AttackArea.SetActive((attacking));
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        AttackArea.SetActive(attacking);
    }*/
}
