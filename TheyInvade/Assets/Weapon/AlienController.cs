using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
  
    public GameObject firePoint;
    public Weapon weapon;
    public bool onCamera = false;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnBecameInvisible()
    {
        onCamera = false;
    }
    private void OnBecameVisible()
    {
        onCamera = true;
    }



    // Update is called once per frame
    void Update()
    {
        if (firePoint != null)
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

            

            if (playerPos.x - transform.position.x < 10 && onCamera == true)
            {
               weapon.Attacking = true;
            }
            else
            {
                weapon.Attacking = false;
            }
        }
    }
}

