using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableObject : CollidableObject
{
    // private bool z_Interacted = false;
    public TMP_Text pressKey;
    protected override void OnCollided(GameObject collidedObject)
    {
        pressKey.text = "Press 'E'";
        if (Input.GetKey(KeyCode.E))
        {
            OnInteract();
        }
    }

    private void OnInteract()
    {
        // if (!z_Interacted)
        // {
        //     z_Interacted = true;
        // }
        pressKey.text = " ";
        Debug.Log("Interact with" + name);
    }
}
