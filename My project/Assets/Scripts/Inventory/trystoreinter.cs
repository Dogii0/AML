using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trystoreinter : MonoBehaviour
{
    void start()
    {
        
    }
    public void close_ui()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}

