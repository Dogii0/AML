using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using TMPro;
using UnityEngine;

public class StoreInter : CollidableObject
{
    private bool z_Interacted = false;
    public TMP_Text pressKey;
    private GameObject player;
    public GameObject storeUI;
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    protected override void OnCollided(GameObject collidedObject)
    {
        if (collidedObject == player)
        {
            if (!z_Interacted)
            {
                pressKey.text = "Press 'V'";
            }

            if (Input.GetKey(KeyCode.V) && !z_Interacted)
            {
                z_Interacted = true;
                pressKey.text = " ";
                storeUI.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
