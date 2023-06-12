using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DoorSceneChange : CollidableObject
{
    public TMP_Text pressKey;
    public int sceneID;
    private bool z_Interacted = false;
    public static bool changeable = true;
    protected override void OnCollided(GameObject collidedObject)
    {
        if (!z_Interacted)
        {
            pressKey.text = "Press 'E'";
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            z_Interacted = true;
            if (changeable)
            {
                pressKey.text = " ";
                SceneManager.LoadScene(sceneID);
            }
            else
            {
                pressKey.text = "Please defeat the Boss!!";
            }
            
        }
    }
}
