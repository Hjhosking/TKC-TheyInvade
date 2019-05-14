using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    private PlayerStats playerStats;
    private int playerShot;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player")
        {
            Debug.Log(hitInfo.name);
            playerShot = -1; //subtract 1 from player healh
            playerStats.updateCurrentHealth(playerShot);
            Destroy(gameObject);
        }
    }
}
