using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private float fallRespawn;

    [SerializeField]
    private float maxRespawn = 3;
    public int currentRespawn = 0;
    private int score = 0;
    
    [SerializeField]
    private PlayerStats character;

    public Transform spawnPosition;
    public Transform playerTransform;
    public static bool dead = false;
    public static int deathCount;

    

    



    private void Start()
    {
        playerTransform.position = spawnPosition.position;
        deathCount = currentRespawn;

    }

    // Update is called once per frame
    void Update()
    {
        deathCount = currentRespawn;

        // Check if player has fallen below given threshold
        if (playerTransform.position.y < fallRespawn || character.CurrentHealth == 0)
        {
            dead = true;
        }
        if (dead)
        {
            // Trnsform player back to spawn point and deduct a life
            playerTransform.position = spawnPosition.position;
            character.CurrentLives--;
            currentRespawn++;
            dead = false;

            if (this.currentRespawn >= 3)
            {
                Debug.Log("Failure!");
            }
        }
        

        
        
    }
    

}
