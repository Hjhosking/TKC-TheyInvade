using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallingSign : MonoBehaviour
{
    // This script controls the falling platforms, detecting collision from player tagged objects, waiting a set delay amount then falling away
    private Rigidbody2D rb2d;

    public float fallDelay;

    // Start is called before the first frame update
    void Start()
    {
        // get rigidbody of object
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Bullet") // this string is your newly created tag
        {
            StartCoroutine(Fall());
        }
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
}

