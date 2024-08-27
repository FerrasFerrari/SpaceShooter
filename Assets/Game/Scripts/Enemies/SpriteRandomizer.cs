using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRandomizer : MonoBehaviour
{
    //public Sprite[] sprites;
    Animator animator;

    void Start()
    {
        //GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        animator = GetComponent<Animator>();
        if(Random.Range(0,2) == 1)
        {
            animator.SetTrigger("IsVariant");
        }
    }

    void Update()
    {
        
    }
}
