using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelFinish : MonoBehaviour
{
    public bool playerDetected = false;
    public int LevelToLoad;
    public float countDownTimer;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (playerDetected)
        {
            countDownTimer -= Time.deltaTime;
            if (countDownTimer < 0)
                countDownTimer = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerDetected = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerDetected = true;
            if (countDownTimer == 0)
            {
                SceneManager.LoadScene(LevelToLoad);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerDetected = false;
        }
    }
    
}
