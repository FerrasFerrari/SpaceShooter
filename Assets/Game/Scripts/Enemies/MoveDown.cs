using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float moveSpeed;
   // public float yPosition;
    Vector2 enemyVelocity;
    public float stopYline;
    public bool doesStop = false;
    private bool stop = false;
    Gun[] guns;

    void Start()
    {
        //transform.position = new Vector3(transform.position.x, yPosition, 0);
        LookForGuns();
    }

    void FixedUpdate()
    {
        Movement();
    }
    void Movement(){
        /*enemyVelocity = new Vector2(myRigid.velocity.x, -moveSpeed);
        myRigid.velocity = enemyVelocity; */
        if (transform.position.y <= stopYline && doesStop) {
            if (!stop)
            {
                foreach (Gun gun in guns)
                {
                    gun.canShoot = true;
                }
                stop = true;
            }
            return; 
        }
        Vector2 pos = transform.position;

        pos.y -= moveSpeed * Time.fixedDeltaTime;

        transform.position = pos;
    }
    public void LookForGuns()
    {
        guns = transform.GetComponentsInChildren<Gun>();
    }
}
