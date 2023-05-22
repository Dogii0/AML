using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlacer : MonoBehaviour
{
    [SerializeField] private Vector2 startPos;
     
    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = startPos;
    }
}
