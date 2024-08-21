using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{

    Renderer mRenderer;
    public float speed;
    void Start()
    {
        mRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        mRenderer.material.mainTextureOffset = new Vector2(Time.time * speed / 5, 0);
    }
}
