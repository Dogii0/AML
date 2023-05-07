using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private Inventory inventory;

    [SerializeField] private UI_Inventory uiInventory;
    
    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        //ItemWorld.SpawnItemWorld(new Vector3(20, 20), new Item { itemType = Item.ItemType.Tree, amount = 1 });
    }
    void Start()
    {
        transform.position = new Vector3(0,0,0);
    }
    void Update()
    {
        transform.Translate(Vector3.right*Time.deltaTime*speed*Input.GetAxis("Horizontal"));
        transform.Translate(Vector3.up*Time.deltaTime*speed*Input.GetAxis("Vertical"));
    }

    
}
