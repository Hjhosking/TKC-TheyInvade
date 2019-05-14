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
   
    private int score = 0;
    
    [SerializeField]
    private PlayerStats character;

    public Transform spawnPosition;
    public Transform playerTransform;
    public static bool dead = false;
    public static int deathCount = 0;








    private void Start()
    {
        playerTransform.position = spawnPosition.position;
        

    }

    // Update is called once per frame
    void Update()
    {
        

        // Check if player has fallen below given threshold
        if (playerTransform.position.y < fallRespawn || character.CurrentHealth == 0)
        {
            dead = true;
        }
        if (dead && (deathCount <= maxRespawn))
        {
            // Trnsform player back to spawn point and deduct a life
            playerTransform.position = spawnPosition.position;
            character.CurrentLives--;
            deathCount++;
            dead = false;

        }
        else
        {
           //game over sequence
            
        }
        

        
        
    }
    

}
