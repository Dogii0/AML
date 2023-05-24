using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntObjVendingMachine : MonoBehaviour
{
    public GameObject storeUI;
    private bool z_Interacted = false;
    public TMP_Text pressKey;
    public static bool open = false;
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if (other.gameObject == player)
        {
            if (!z_Interacted)
            {
                pressKey.text = "Press 'V'";
            }

            if (Input.GetKey(KeyCode.V))
            {
                pressKey.text = " ";
                z_Interacted = true;
            }
        }
        if (Input.GetKey(KeyCode.V) && z_Interacted)
        {
            if (!open)
            {
                storeUI.SetActive(true);
                open = true;
            }
            else
            {
                storeUI.SetActive(false);
                open = false;
            }
            Debug.Log("key pressed");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            z_Interacted = false;
        }
    }
}
