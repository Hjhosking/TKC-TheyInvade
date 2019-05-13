using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw : deathCollider
{
    // Start is called before the first frame update
    private float nextRotation = 0;
    private float rotationAngle = 0f;
    private bool visable = false;
    
    private void OnBecameVisible()
    {
        visable = true;
    }

    private void spin()
    {
        float waitTime = .05f;

        if (Time.time > nextRotation)
        {
            nextRotation = Time.time + waitTime;
            rotationAngle -=5;
            transform.localRotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (visable == true)
        {
            spin();
        }
    }
}
