using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemSpawner : MonoBehaviour
{
    public Item item;

    private void Awake()
    {
        ItemWorld.SpawnItemWorld(transform.position, item);
        //ItemWorld.SpawnItemWorld(new Vector3(1, 1), item);
        //ItemWorld.SpawnItemWorld(transform.position, new Item { itemType = Item.ItemType.Tree, amount = 1 });
        Destroy(gameObject);
    }
}
