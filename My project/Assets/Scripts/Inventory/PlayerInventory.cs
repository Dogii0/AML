using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Inventory inventory;
    public static Item weapon = null;

    [SerializeField] private UI_Inventory uiInventory;

    private void Start()
    {
    }

    private void Awake()
    {
        inventory = new Inventory();
        inventory.AddItem(new Item { itemType = Item.ItemType.Coin, amount = 10 });
        uiInventory.SetInventory(inventory);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            Debug.Log("pickup");
            if (!itemWorld.GetItem().IsStackable())
            {
                if (weapon != null)
                {
                    ItemWorld.DropItem(weapon);
                    inventory.RemoveItem(weapon);
                }
                weapon = itemWorld.GetItem();
            }
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
}
