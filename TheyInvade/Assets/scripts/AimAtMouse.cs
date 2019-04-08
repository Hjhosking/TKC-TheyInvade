using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtMouse : MonoBehaviour
{

    bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (mousePos.x >= 0 && !facingRight)
        {
            facingRight = true;
        }
        else if (mousePos.x < 0 && facingRight)
        {
            facingRight = false;
        }

        Vector3 mousePosition = Input.mousePosition;
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePosition);

        lookPos = lookPos - transform.position;

        if (!facingRight)
        {
            lookPos.y *= -1;
            lookPos.x *= -1;
        }

        float aimAngle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(aimAngle, Vector3.forward);



    }
}
