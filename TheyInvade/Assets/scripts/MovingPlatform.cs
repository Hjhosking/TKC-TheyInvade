using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject player;

    public GameObject platform;

    public float moveSpeed;

    public Transform currentPoint;

    public Transform[] points;

    private int pointSelection;

    private Rigidbody2D rb2d;
    private Rigidbody2D playerRB;

    private bool riding = false;


    // Start is called before the first frame update
    void Start()
    {
        // Set the first poitn to move to
        currentPoint = points[pointSelection];
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Start platform moving towards first destination
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

        // When platform reaches destination, update currentPoint so that it becomes the next destination but doesnt move outside the array list
        if (platform.transform.position == currentPoint.position)
        {
            pointSelection++;

            if (pointSelection == points.Length)
            {
                pointSelection = 0;
            }

            currentPoint = points[pointSelection];
        }

        if (riding)
        {
            playerRB = player.GetComponent<Rigidbody2D>();
            playerRB.velocity = rb2d.velocity;

        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            riding = true;
        }
            
    }
}
