using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMovement : MonoBehaviour
{
    float sinXOffset;
    float sinYOffset;
    public float amplitude = 1;
    public float frequency = 1;
    public bool inverted;
    public bool flipXY;
    void Start()
    {
        sinXOffset = transform.position.x;
        sinYOffset = transform.position.y;
    }

    void Update()
    {
        
    }
    private void FixedUpdate() {
        Vector2 pos = transform.position;
        if (!flipXY)
        {
            float sin = Mathf.Sin(pos.y * frequency) * amplitude;
            if (inverted)
            {
                sin *= -1;
            }
            pos.x = sinXOffset + sin;
        }else{
            float sin = Mathf.Sin(pos.x * frequency) * amplitude;
            if (inverted)
            {
                sin *= -1;
            }
            pos.y = sinYOffset + sin;
        }
        
        transform.position = pos;
    }
}
