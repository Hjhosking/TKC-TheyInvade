using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private Stat health;
    [SerializeField]
    private Stat lives;
    private float currentHealth;
    private float currentLives;

    public float CurrentLives
    {
        get
        {
            return this.currentLives;
        }
        set
        {
            this.currentLives = value;
        }
    }

    public float CurrentHealth
    {
        get
        {
            return this.currentHealth;
        }
    }

        

    void Awake()
    {
        health.Initialize();
        lives.Initialize();
        this.currentLives = 3;
        this.currentHealth = 3;
    }

    public void updateCurrentHealth(int damage)
    {
        health.CurrentVal = health.CurrentVal + damage;
        print(health.CurrentVal);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            this.currentHealth--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            this.currentHealth--;
        }
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health.CurrentVal > this.CurrentHealth)
        {
            health.MaxVal = 3;
            health.CurrentVal = this.CurrentHealth;
            if (health.CurrentVal == 0 && lives.CurrentVal > 0)
            {
                this.currentHealth = 3;
            }
        }
        if (lives.CurrentVal > this.currentLives)
        {
            lives.MaxVal = 3;
            lives.CurrentVal = this.currentLives;
            health.CurrentVal = 3;
        }

    

        if (health.CurrentVal == 0)
        {
            lives.CurrentVal --;
            this.currentLives = lives.CurrentVal;
            if (lives.CurrentVal > 0)
            {
                health.CurrentVal = 3;
            }
        }
    }
}
