using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        BulletScript bullet = other.gameObject.GetComponent<BulletScript>();
        if(bullet != null){
            if(!bullet.isEnemy){
                Destroy(gameObject);
                Destroy(bullet.gameObject);
            }
        }
    }
}
