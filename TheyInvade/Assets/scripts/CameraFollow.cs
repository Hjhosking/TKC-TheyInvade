using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPositon;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    private void FixedUpdate()
    {
        Vector2 playerPos = new Vector2(playerPositon.position.x, playerPositon.position.y);
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
        
        transform.position = new Vector3(playerPos.x, playerPos.y, -10);
    }
}
