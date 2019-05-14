using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            LevelManager.dead = true;
        }

    }
}
