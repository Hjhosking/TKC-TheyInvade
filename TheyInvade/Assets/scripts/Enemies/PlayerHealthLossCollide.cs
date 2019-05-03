using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealthLossCollide : MonoBehaviour
{
 public float currentHealth;

    void OnTriggerEnter(Collider other)
    {
        currentHealth = currentHealth - 1; //subtract 1 from player health
    }

    // Update is called once per frame
    void Update()
    {

    }
}
