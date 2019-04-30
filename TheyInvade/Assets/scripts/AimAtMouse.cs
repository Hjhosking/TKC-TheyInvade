using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtMouse : MonoBehaviour
{
    bool facingRight = true;
    private int maxAngle = 35;
    private int minAngle = -35;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check if mouse is left or right of player and set bool facingRight accordingly
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (mousePos.x >= 0 && !facingRight)
        {
            facingRight = true;
        }
        else if (mousePos.x < 0 && facingRight)
        {
            facingRight = false;
        }

        // convert mouse position to vector3
        Vector3 mousePosition = Input.mousePosition;
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePosition);
        
        //create a vector3 thats relative to player based on mouse position
        lookPos = lookPos - transform.position;

        // if player is facing left then set values to negative
        if (!facingRight)
        {
            lookPos.y *= -1;
            lookPos.x *= -1;
        }

        //calculate angle from player to mouse
        float aimAngle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;

        // rotate player object to face mouse
        // if limits angle of aim
        if (aimAngle >= minAngle && aimAngle <= maxAngle)
        {
            transform.rotation = Quaternion.AngleAxis(aimAngle, Vector3.forward);
        }


    }
    
}
