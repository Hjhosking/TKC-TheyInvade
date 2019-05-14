using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    
    AlienController alien;
    
    //When killzone collider is triggered, send message to alien controller to begin/stop firing
    void OnTriggerEnter2D(Collider2D collision)
    {
         alien = GetComponentInParent<AlienController>();
        if (collision.gameObject.tag == "Player")
        {
           
            Debug.Log(collision);

            alien.CanShoot = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Exit");

            alien.CanShoot = false;
        }
    }
}