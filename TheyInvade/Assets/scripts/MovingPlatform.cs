using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public GameObject platform;

    public float moveSpeed;

    public Transform currentPoint;

    public Transform[] points;

    private int pointSelection;

    // Start is called before the first frame update
    void Start()
    {
        // Set the first poitn to move to
        currentPoint = points[pointSelection];
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
    }
}
