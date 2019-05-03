using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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

    void Awake()
    {
        health.Initialize();
        lives.Initialize();
        this.currentLives = 3;
        this.currentHealth = 3;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lives.CurrentVal > this.currentLives)
        {
            lives.MaxVal = 3;
            lives.CurrentVal = this.currentLives;
            health.CurrentVal = 3;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            health.MaxVal = 3;
            health.CurrentVal -= 1;
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
