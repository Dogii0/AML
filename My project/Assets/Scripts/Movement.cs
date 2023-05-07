using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private Inventory _inventory;

    [SerializeField] private UI_Inventory uiInventory;
    
    private void Awake()
    {
        _inventory = new Inventory();
        uiInventory.SetInventory(_inventory);
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
