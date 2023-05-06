using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableObject : CollidableObject
{
    private bool z_Interacted = false;
    public TMP_Text pressKey;
    protected override void OnCollided(GameObject collidedObject)
    {
        if (!z_Interacted)
        {
            pressKey.text = "Press 'V'";
        }
        
        if (Input.GetKey(KeyCode.V))
        {
            z_Interacted = true;
            pressKey.text = " ";
            Debug.Log("key pressed");
        }
    }
}
