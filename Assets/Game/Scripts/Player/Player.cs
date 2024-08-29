using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    //public float rotSpeed;
    public float yPosition;
    Vector2 moveInput;
    Rigidbody2D myRigid;
    Gun[] guns;
    private void Awake() {
        myRigid = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        LookForGuns();
        transform.position = new Vector3(0, yPosition, 0);
    }



    void FixedUpdate()
    {
        Movement();
    }
    void OnFire(){
        foreach(Gun gun in guns){
            gun.Shoot();
        }
    }
    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
    }
    private void Movement(){
        Vector2 playerVelocity = new Vector2(moveSpeed * moveInput.x, myRigid.velocity.y);
        myRigid.velocity = playerVelocity; 
        //myRigid.AddTorque(-rotSpeed * moveInput.x / 10);
        //myRigid.AddRelativeForce(Vector2.up * moveSpeed * moveInput.y);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(LayerMask.LayerToName(other.gameObject.layer) == "Enemy"){
            Die();
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        BulletScript bullet = other.gameObject.GetComponent<BulletScript>();
        if(bullet != null && bullet.isEnemy){
                Die();
                ObjectPoolManager.DestroyObject(bullet.gameObject);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    public void LookForGuns(){
        guns = transform.GetComponentsInChildren<Gun>();
    }
}
