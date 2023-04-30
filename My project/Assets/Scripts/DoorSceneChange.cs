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
    protected override void OnCollided(GameObject collidedObject)
    {
        if (!z_Interacted)
        {
            pressKey.text = "Press 'E'";
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            z_Interacted = true;
            pressKey.text = " ";
            SceneManager.LoadScene(sceneID);
        }
    }
}
