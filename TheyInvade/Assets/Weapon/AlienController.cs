using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{

    public GameObject firePoint;
    public Weapon weapon;
    public bool onCamera = false;
    private bool canShoot = false;


    //Receive trigger message from KillZone & relay to weapon 
    public bool CanShoot {
        get {
            return canShoot;                }
        set {
            this.canShoot = value;
            weapon.CanShoot = value;
        }
    }


    // Update is called once per frame
    void Update()
    {
            
        
            //Find the posistion of the player 
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            var playerPos = player.transform.position;

            // Rotate to face players direction 
            if (playerPos.x <= this.transform.position.x)
            {
                transform.localScale = new Vector3(1f, 1f, 1);
                //Changes direction of bullet trajectory 
                firePoint.transform.localRotation = Quaternion.AngleAxis(180f, Vector3.forward);
            }
             else if (playerPos.x > this.transform.position.x)
            {
                transform.localScale = new Vector3(-1f, 1f, 1);
                //Changes direction of bullet trajectory 
                firePoint.transform.localRotation = Quaternion.AngleAxis(0f, Vector3.forward);
            }

            

       
    }
}

