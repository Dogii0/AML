using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUse : UI_Inventory
{
    public Button button;
    private Vector2 location;
    private GameObject player;
    // private Item item;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        location = player.transform.position;
    }
    
    void Start () {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(OnMouseDown);
    }
    public void OnMouseDown()
    {
        // inventory.RemoveItem(item);
        // RefreshInventoryItems();
        ItemWorld.DropItem(player.transform.position,  new Item { itemType = Item.ItemType.Tree, amount = 1 });
        // ItemWorld.SpawnItemWorld(location  , new Item { itemType = Item.ItemType.Tree, amount = 1 });
    }
}
