using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    // This script controls the falling platforms, detecting collision from player tagged objects, waiting a set delay amount then falling away
    private Rigidbody2D rb2d;
    public float fallDelay;
    public GameObject Platform;
    public bool dead = false;
    int respawn = 0;
    Vector2 spawnPoint;
    public int respawnNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        // get rigidbody of object
        rb2d = GetComponent<Rigidbody2D>();
        spawnPoint = new Vector2(Platform.transform.position.x, Platform.transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Detect collision with player and start fall routine
        if (col.collider.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }
    IEnumerator Fall()
    {
        // Return wait delay for given time
        yield return new WaitForSeconds(fallDelay);
        // set platform to not kinematic so it falls
        rb2d.isKinematic = false;
        // return 0 so countdown ends
        yield return 0;
    }

    private void Update()
    {
        dead = LevelManager.dead;
        if (dead)
        {
            rb2d.isKinematic = true;
            Platform.transform.position = spawnPoint;

        }
    }
}
