using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using TMPro;

public class Instruction : CollidableObject
{
    private bool z_Interacted = false;
    public TMP_Text pressKey;
    private GameObject player;
    public GameObject instUI;
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
                pressKey.text = "Press 'X'";
                z_Interacted = true;
            }

            if (Input.GetKey(KeyCode.X))
            {
                pressKey.text = " ";
                instUI.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
    
    public void close_ui()
    {
        instUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
