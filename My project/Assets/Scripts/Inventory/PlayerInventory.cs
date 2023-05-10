using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] private UI_Inventory uiInventory;
    
    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        
        // ItemWorld.SpawnItemWorld(new Vector3(1, 1), new Item { itemType = Item.ItemType.Tree, amount = 1 });
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
    
    void Start()
    {
        ItemWorld.SpawnItemWorld(new Vector3(1, 1), new Item { itemType = Item.ItemType.Tree, amount = 1 });
    }
}
