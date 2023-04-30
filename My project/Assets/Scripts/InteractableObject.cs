using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : CollidableObject
{
    private bool z_Interacted = false;
    public TMP_Text pressKey;
    protected override void OnCollided(GameObject collidedObject)
    {
        if (!z_Interacted)
        {
            pressKey.text = "Press 'E'";
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            z_Interacted = true;
            // OnInteract();
            pressKey.text = " ";
        }
    }

    // private void OnInteract()
    // {
    //     Debug.Log("Interact with" + name);
    // }
}
