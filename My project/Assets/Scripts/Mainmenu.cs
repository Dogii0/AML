using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
   public void play_game()
   {
      SceneManager.LoadScene(1);
   }

   public void quit()
   {
      Application.Quit();
   }
   
}
