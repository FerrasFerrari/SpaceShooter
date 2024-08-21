using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CalculateCameraBox : MonoBehaviour
{
    private Camera camComp;
    // private BoxCollider2D boxColl;
    // private float sizeX, sizeY, ratio;
    EdgeCollider2D edgeCollider;
    private void Awake() {
        edgeCollider = GetComponent<EdgeCollider2D>();
        camComp = GetComponent<Camera>();
        
    }

    private void SetEdgeCollider()
    {
        List<Vector2> edges = new List<Vector2>
        {
            camComp.ScreenToWorldPoint(Vector2.zero),
            camComp.ScreenToWorldPoint(new Vector2(Screen.width, 0)),
            camComp.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)),
            camComp.ScreenToWorldPoint(new Vector2(0, Screen.height)),
            camComp.ScreenToWorldPoint(Vector2.zero)
        };
        edgeCollider.SetPoints(edges);
    }

    void Start()
    {
        
        SetEdgeCollider();

        // camComp = GetComponent<Camera>();
        // boxColl = GetComponent<BoxCollider2D>();
        // sizeY = camComp.orthographicSize * 2;
        // ratio = (float)Screen.width / (float)Screen.height;
        // sizeX = sizeY * ratio;
        // boxColl.size = new Vector2(sizeX, sizeY);

    }

    void Update()
    {
        
    }
}
