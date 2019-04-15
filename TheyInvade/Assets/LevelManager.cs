using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int hitPoint = 3;
    private int score = 0;

    public Transform spawnPosition;
    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.y < -7)
        {
            playerTransform.position = spawnPosition.position;
            hitPoint--;
            if (hitPoint <= 0)
            {
                Debug.Log("Failure!");
            }
        }
        
    }
}
