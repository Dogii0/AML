using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneChange : MonoBehaviour
{
    public int sceneID;
    void Awake(){
    SceneManager.LoadScene(sceneID);
    }
}
