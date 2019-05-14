using UnityEngine;

public class AudioScript : MonoBehaviour
{

    public AudioClip playerGun;
    public AudioClip enemyGun;

    public AudioSource playerGunSource;
    public AudioSource enemyGunSource; 

    // Start is called before the first frame update
    void Start()
    {
        playerGunSource.clip = playerGun;
        enemyGunSource.clip = enemyGun;

}

    // Update is called once per frame
    void Update()
    {
      if (Input.GetButtonDown("Fire1"))
        {
            playerGunSource.Play();
        }

    }
}
