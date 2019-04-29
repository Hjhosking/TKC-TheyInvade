using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float fallRespawn;
    private int hitPoint = 3;
    private int score = 0;

    public Transform spawnPosition;
    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.y < fallRespawn)
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
