using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Animator animator;
    public float speed;
    void Start()
    {
        transform.position = new Vector3(0,0,0);
    }
    void Update()
    {
        transform.Translate(Vector3.right*Time.deltaTime*speed*Input.GetAxis("Horizontal"));
        transform.Translate(Vector3.up*Time.deltaTime*speed*Input.GetAxis("Vertical"));

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        
        animator.SetFloat("moveX", moveX);
        animator.SetFloat("moveY", moveY);
        
        bool isMoving = !Mathf.Approximately(moveX, 0f);
        if (isMoving == false) isMoving = !Mathf.Approximately(moveY, 0f);

        animator.SetBool("isMoving", isMoving);
    }
}