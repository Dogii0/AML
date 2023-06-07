using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Store : CollidableObject
{
    private bool z_Interacted = false;
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
            if (!z_Interacted)
            {
                pressKey.text = "Press 'V'";
            }

            if (Input.GetKey(KeyCode.V) && !z_Interacted)
            {
                z_Interacted = true;
                pressKey.text = " ";
                ItemWorld.SpawnItemWorld(transform.position, new Item { itemType = Item.ItemType.Kimbap, amount = 1 });
                // Debug.Log("key pressed");
            }
        }
    }
}
