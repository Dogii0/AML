using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void Start() {
        PolygonCollider2D poly = GetComponent<PolygonCollider2D>();
        if(poly == null){
            // poly ui = gameObject.AddComponent<PolygonCollider2D>();
        }
        Vector2[] points = poly.points;
        EdgeCollider2D edge = gameObject.AddComponent<EdgeCollider2D>();
        edge.points = points;
        Destroy(poly);
    }
}
