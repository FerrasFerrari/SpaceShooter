using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    Animator animator;
    public MoveDown moveDownScript;
    public MoveHorizontal moveHorizontalScript;
    void Start()
    {
        animator = GetComponent<Animator>();
        moveDownScript = GetComponent<MoveDown>();
        moveHorizontalScript = GetComponent<MoveHorizontal>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        BulletScript bullet = other.gameObject.GetComponent<BulletScript>();
        if(bullet != null){
            if(!bullet.isEnemy){
                if (moveDownScript != null)
                {
                    moveDownScript.moveSpeed = 0;
                }
                else
                {
                    moveHorizontalScript.moveSpeed = 0;
                }
                animator.SetBool("IsDead", true);
                //Destroy(gameObject);
                ObjectPoolManager.DestroyPooled(bullet.gameObject);
            }
        }
    }
}
