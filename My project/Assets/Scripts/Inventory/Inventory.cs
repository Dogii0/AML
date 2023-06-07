using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;
    private static List<Item> itemList;
    private Action<Item> useItemAction;
    private Item weapon = null;
    private static Vector2 location;
    private GameObject player;
    public PlayerHealth playerHealth;
    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        location = player.transform.position;
    }
    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.Coin, amount = 10 });
        //AddItem(new Item { itemType = Item.ItemType.FireExt, amount = 1 });
    }

    public void AddItem(Item item)
    {
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }

            if (!itemAlreadyInInventory)
            {
                itemList.Add(item);
            }
        }
        else
        {
            if (weapon != null)
            {
                ItemWorld.DropItem(weapon);
                itemList.Remove(weapon);
            }
            weapon = item;
            itemList.Add(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }

            if (itemInInventory != null && itemInInventory.amount <=0)
            {
                itemList.Remove(itemInInventory);
            }
        }
        else
        {
            itemList.Remove(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(Item item)
    {
        if (item.IsFood())
        {
            playerHealth.Heal(0.5);
            Debug.Log("food bruh");
        }
        else
        {
            Debug.Log("not food bruh");
        }
    }
    
    public List<Item> GetItemList()
    {
        return itemList;
    }

    public Item getWeaponType()
    {
        return weapon;
    }
}