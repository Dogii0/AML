using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreCollide : MonoBehaviour
{
    protected Collider2D z_Collider;
    [SerializeField]
    private ContactFilter2D z_Filter;
    public GameObject storeUI;
    private List<Collider2D> z_CollidedObjects = new List<Collider2D>(1);
    public static bool open = false;
    public static bool interact = false;

    protected virtual void Start()
    {
        z_Collider = GetComponent<Collider2D>();
    }

    protected virtual void Update()
    {
        z_Collider.OverlapCollider(z_Filter, z_CollidedObjects);
        foreach (var o in z_CollidedObjects)
        {
            OnCollided(o.gameObject);
        }

        if (Input.GetKey(KeyCode.V)&&interact)
        {
            if (!open)
            {
                storeUI.SetActive(true);
                open = true;
            }
            else
            {
                storeUI.SetActive(false);
                open = false;
            }
            Debug.Log("key pressed");
        }
    }

    protected virtual void OnCollided(GameObject collidedObject)
    {
        // Debug.Log("Collided with" + collidedObject.name);
    }
}
