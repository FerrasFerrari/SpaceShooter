using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOld : MonoBehaviour
{

    public float playerSpeed;
    public float rotSpeed;
    public float yPosition;
    Vector2 moveInput;
    Rigidbody2D myRigid;
    Vector2 playerVelocity;
    
    private void Awake() {
        myRigid = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        transform.position = new Vector3(0, yPosition, 0);
    }



    void FixedUpdate()
    {
        Movement();
    }
    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
    }
    private void Movement(){
        //playerVelocity = new Vector2(playerSpeed * moveInput.x, myRigid.velocity.y);
        //myRigid.velocity = playerVelocity; 
        myRigid.AddTorque(-rotSpeed * moveInput.x / 10);
        myRigid.AddRelativeForce(Vector2.up * playerSpeed * moveInput.y);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(LayerMask.LayerToName(other.gameObject.layer) == "Enemy"){
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
