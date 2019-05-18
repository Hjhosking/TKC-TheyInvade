using UnityEngine;

public class Level1AudioScript : MonoBehaviour
{

    public AudioClip playerGun;
    public AudioClip enemyGun;

    public AudioSource playerGunSource;
    public AudioSource enemyGunSource;

    private bool soundPlay;

    // Start is called before the first frame update
    void Start()
    {
        soundPlay = false;
        playerGunSource.clip = playerGun;
        enemyGunSource.clip = enemyGun;
        }

    // Update is called once per frame
    public void Update()
    { 
      if (Input.GetButtonDown("Fire1"))
        {
            playerGunSource.Play();
        }
        if (soundPlay != false)
        {
            enemyGunSource.Play();
            soundPlay = false;
        }
    }

    public void playEnemyGunSound()
    {
        soundPlay = true;
    }
}
