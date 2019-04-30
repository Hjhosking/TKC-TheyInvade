using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // This script makes the camera follow the player whilst staying inside a boundary set by the min/max x and y values
    public Transform playerPositon;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    private void FixedUpdate()
    {
        // Convert players transform to a vector
        Vector2 playerPos = new Vector2(playerPositon.position.x, playerPositon.position.y);

        // Check if outside boundaries and limit if so
        if (playerPos.x <= minX)
        {
            playerPos.x = minX;
        }
        if (playerPos.y <= minY)
        {
            playerPos.y = minY;
        }
        if (playerPos.x >= maxX)
        {
            playerPos.x = maxX;
        }
        if (playerPos.y >= maxY)
        {
            playerPos.y = maxY;
        }
        // Transform camera to new vector closest to player within boundary
        transform.position = new Vector3(playerPos.x, playerPos.y, -10);
    }
}
