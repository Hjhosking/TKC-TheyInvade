using System.Collections;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float timer = 0.0f;
    public bool canShoot = false;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (canShoot == true)
            {
                Shoot();
            }
            if (canShoot == false)
            {
                timer = 0.0f;
            }
            else
            {
                timer = 1.0f;
            }
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void canShootTrue(bool sent)
    {
        this.canShoot = sent;
        Debug.Log(sent);
    }

    public void canShootFalse(bool sent)
    {
        this.canShoot = sent;
        Debug.Log("false");
    }
}
