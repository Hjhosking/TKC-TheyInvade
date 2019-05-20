using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool isPlayer = false;
    float timer = 0.0f;
    private bool canShoot = false;
    public AudioClip alienGunSound;
    public AudioClip playerGunSound;
    private AudioSource alienSoundSource;
    private AudioSource playerSoundSource;

    void Awake()
    {

        alienSoundSource = GetComponent<AudioSource>();
        playerSoundSource = GetComponent<AudioSource>();
    }

    //trigger for enemy fire - receives command realayed from AlienController
    public bool CanShoot
    {
        get
        {
         return this.canShoot;
        }
        set
        {
            canShoot = value;
        }
    }

    //Enemy fire timer 
    void enemyAttack()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (canShoot == true)
            {
                alienSoundSource.Play();
                Shoot();
            }
            if (canShoot == false)
            {
                timer = 0.0f;
            }
            else
            {
                timer = .80f;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Player fire 
        if (isPlayer && Input.GetButtonDown("Fire1"))
        {
            playerSoundSource.Play();
            Shoot();

        }

        else if (isPlayer == false && canShoot == true)
        {
            enemyAttack();
        }
    }

    void Shoot ()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
