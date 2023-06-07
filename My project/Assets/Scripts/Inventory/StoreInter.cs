using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StoreInter : CollidableObject
{
    private bool z_Interacted = false;
    public TMP_Text pressKey;
    private GameObject player;
    public GameObject quizUI;
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
                pressKey.text = "Press 'Q'";
            }

            if (Input.GetKeyDown(KeyCode.Q) && !z_Interacted)
            {
                z_Interacted = true;
                pressKey.text = " ";
                quizUI.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
    public void close_ui_correctanswer()
    {
        quizUI.SetActive(false);
        Time.timeScale = 1f;
        ItemWorld.SpawnItemWorld(player.transform.position, new Item { itemType = Item.ItemType.Kimbap, amount = 1 });
        Debug.Log("drop harusnya");
        z_Interacted = true;
    }

    public void close_ui_wronganswer()
    {
        quizUI.SetActive(false);
        Time.timeScale = 1f;
        z_Interacted = false;
    }
}
