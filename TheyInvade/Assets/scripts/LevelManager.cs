using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private float fallRespawn;

    [SerializeField]
    private float maxRespawn = 3;
    private int currentRespawn = 0;
    private int score = 0;
    
    [SerializeField]
    private Player character;

    public Transform spawnPosition;
    public Transform playerTransform;

    


    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.y < fallRespawn)
        {
            playerTransform.position = spawnPosition.position;
            character.CurrentLives--;

            if (this.currentRespawn >= 3)
            {
                Debug.Log("Failure!");
            }
        }
        
    }
}
