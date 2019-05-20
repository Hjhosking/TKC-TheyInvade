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

    public GameObject gameOver;

    public int deathCount = 0;

    public float CurrentLives
    {
        get
        {
            return this.currentLives;
        }
        set
        {
            currentLives = value;
            lives.CurrentVal = value;
        }
    }

    public void Respawn()
    {
        CurrentHealth = 0;
        CurrentLives--;
        if (CurrentLives > 0)
        {
            CurrentHealth = 3;
        }
        else
        {
            gameOver.SetActive(true);
        }
        deathCount++;
    }
    public float CurrentHealth
    {
        get
        {
            return this.currentHealth;
        }
        set
        {
            currentHealth = value;
            health.CurrentVal = value;
        }
    }

        

    void Awake()
    {
        health.Initialize();
        lives.Initialize();
        this.currentLives = 3;
        this.currentHealth = 3;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            CurrentHealth--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            CurrentHealth--;
        }
    }


  

    // Update is called once per frame
    void Update()
    {
  
        if (CurrentHealth == 0 && CurrentLives > 0)
        {
            Respawn();

        }
        
    }
}
