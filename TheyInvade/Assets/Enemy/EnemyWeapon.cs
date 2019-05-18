using System.Collections;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float timer = 0.0f;
    public bool canShoot = false;
    public bool triggerSound = true;
    public AudioClip gunSound;
    private AudioSource soundSource;

    void Awake()
    {
        soundSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (canShoot == true)
            {
                Shoot();
                soundSource.PlayOneShot(gunSound);
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
   //   level1AudioScript.playEnemyGunSound();
   //     level2AudioScript.PlayEnemyGunSound(triggerSound);
    }

    public void CanShootTrue(bool sent)
    {
        this.canShoot = sent;
        Debug.Log(sent);
    }

    public void CanShootFalse(bool sent)
    {
        this.canShoot = sent;
        Debug.Log("false");
    }
}
