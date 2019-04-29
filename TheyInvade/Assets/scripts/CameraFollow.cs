using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPositon;
   
    private void FixedUpdate()
    {

        transform.position = new Vector3(playerPositon.position.x, (playerPositon.position.y + .5f), transform.position.z);
    }
}
