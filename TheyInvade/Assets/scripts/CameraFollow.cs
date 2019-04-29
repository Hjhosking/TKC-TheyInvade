using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPositon;
    public float yMin;

    private void FixedUpdate()
    {
        Vector2 playerPos = new Vector2(playerPositon.position.x, playerPositon.position.y);
        /*if (playerPos.y < yMin)
        {
            playerPos.y = yMin;
        }
        transform.position = playerPos;*/
        transform.position = new Vector3(playerPositon.position.x, playerPositon.position.y, playerPositon.position.z);
    }
}
