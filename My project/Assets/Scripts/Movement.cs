using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    void Start()
    {
        transform.position = new Vector3(0,0,0);
    }
    void Update()
    {
        transform.Translate(Vector3.right*Time.deltaTime*speed*Input.GetAxis("Horizontal"));
        transform.Translate(Vector3.up*Time.deltaTime*speed*Input.GetAxis("Vertical"));
    }
}
