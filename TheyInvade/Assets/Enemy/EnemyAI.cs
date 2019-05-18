using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private EnemyWeapon enemyWeapon;

    void Awake()
    { 
        //maybe find player colider here or something
    enemyWeapon = FindObjectOfType<EnemyWeapon>();
    }

    // should trigger collision when player contacts sphere collider
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(collision);
            bool send = true;
            enemyWeapon.CanShootTrue(send);
         }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Exit");
            bool send = false;
            enemyWeapon.CanShootFalse(send);  
        }
    }
}

