using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontal : MonoBehaviour
{
    public float moveSpeed;
    public bool moveRight = true;
    // public float yPosition;

    void Start()
    {
        //transform.position = new Vector3(transform.position.x, yPosition, 0);
        if(moveRight){
            transform.rotation = Quaternion.Euler(0, 0, -90); 
        }else{
            transform.rotation = Quaternion.Euler(0, 0, 90); 
        }
    }

    void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        /*enemyVelocity = new Vector2(myRigid.velocity.x, -moveSpeed);
        myRigid.velocity = enemyVelocity; */
        Vector2 pos = transform.position;
        if (moveRight)
        {
            pos.x += moveSpeed * Time.fixedDeltaTime;
        }
        else
        {
            pos.x -= moveSpeed * Time.fixedDeltaTime;
        }

        transform.position = pos;
    }
}
