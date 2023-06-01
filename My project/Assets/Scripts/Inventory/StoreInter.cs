using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreInter : StoreCollide
{
    //private bool z_Interacted = false;
    public TMP_Text pressKey;
    private GameObject player;
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    protected override void OnCollided(GameObject collidedObject)
    {
        if (collidedObject == player)
        {
            if (!interact)
            {
                pressKey.text = "Press 'V'";
            }

            if (Input.GetKey(KeyCode.V) && interact)
            {
                pressKey.text = " ";
                ItemWorld.SpawnItemWorld(transform.position, new Item { itemType = Item.ItemType.Kimbap, amount = 1 });
                // z_Interacted = true;
                interact = true;
            }
        }
    }
}