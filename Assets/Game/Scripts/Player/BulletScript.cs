using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletScript : MonoBehaviour
{
    public float bulletLifetime;
    public float speed;
    public Vector2 direction = Vector2.up;
    public bool isEnemy = false;
    public Quaternion rotation;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddRelativeForce(speed * direction, ForceMode2D.Impulse);
        Destroy(gameObject, bulletLifetime);
    }

    void Update()
    {
        transform.rotation = rotation;
    }
    private void FixedUpdate() {

    }
    private void OnTriggerExit2D(Collider2D other) {
        Camera camera = other.GetComponent<Camera>();
        if (camera != null && !isEnemy) {
            Destroy(gameObject);
        }
    }
}
