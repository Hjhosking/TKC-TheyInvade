using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool isPlayer = false;
    float nextFire = 0;
    private bool attacking = false;

    public bool Attacking
    {
        get
        {
         return this.attacking;
        }
        set
        {
            attacking = value;
        }
    }

    void enemyAttack()
    {
        float waitTime = 1f;

        if (Time.time > nextFire)
        {
            nextFire = Time.time + waitTime;
            Shoot();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer && Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        else if (isPlayer == false && Attacking == true)
        {
            enemyAttack();
        }
    }

    void Shoot ()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
