using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pause_Menu : MonoBehaviour
{
    public static bool Game_is_pause = false;

    public GameObject pausemenuUI;
    public GameObject Inventory;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown((KeyCode.Escape))){
            if (Game_is_pause){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    void Resume(){
        pausemenuUI.SetActive(false);
        Inventory.SetActive(true);
        Time.timeScale = 1f;
        Game_is_pause = false;
    }

    void Pause(){
        pausemenuUI.SetActive(true);
        Inventory.SetActive(false);
        Time.timeScale = 0f;
        Game_is_pause = true;
    }
}
