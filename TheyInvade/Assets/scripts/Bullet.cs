using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;
    public bool playerWeapon = false;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //
        if (hitInfo.gameObject.tag == "Enemy" && playerWeapon == true)
        {
            Debug.Log(hitInfo.name);
            Destroy(hitInfo.gameObject);
            Destroy(gameObject);
        }

        //Bullets destroy on collision with any object other than killZone collider 
    
        else if (hitInfo.gameObject.tag != "enemyTrigger")
        {
           Destroy(gameObject);
        }
    }
}
