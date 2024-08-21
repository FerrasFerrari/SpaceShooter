using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    /* Start is called before the first frame update
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed;*/

    public BulletScript bulletScript;
    Vector2 direction;
    public bool canShoot = false;
    public bool autoShoot = false;
    public float shootIntervalSeconds = 0.5f;
    public float shootDelaySeconds = 0.0f;
    float shootTimer = 0f;
    float delayTimer = 0f;
    void Start()
    {
        
    }
    void Update()
    {
        direction = (transform.rotation * Vector2.up).normalized;

        if (autoShoot)
        {
            if (delayTimer >= shootDelaySeconds)
            {
                if (shootTimer >= shootIntervalSeconds)
                {
                    if (!canShoot) { return; }
                    Shoot();
                    shootTimer = 0;
                }
                else
                {
                    shootTimer += Time.deltaTime;
                }
            }
            else
            {
                delayTimer += Time.deltaTime;
            }
        }
    }
    /*void OnFire()
    {
        GameObject bullet = Instantiate(bulletScript.gameObject, transform.position, Quaternion.identity);
        //bullet.GetComponent<Rigidbody2D>().AddRelativeForce(bulletSpeed * Vector2.up, ForceMode2D.Impulse);
    }*/
    public void Shoot(){
        GameObject bullet = Instantiate(bulletScript.gameObject, transform.position, Quaternion.identity);
        BulletScript bulletD = bullet.GetComponent<BulletScript>();
        bulletD.direction = direction;
        bulletD.rotation = transform.rotation;
    }

}
