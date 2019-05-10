using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public GameObject alienPrefab;
    public Transform[] alienSpawn;

    // Start is called before the first frame update
    void Start()
    {
        alienSpawn = GetComponentsInChildren<Transform>();
        foreach (Transform child in alienSpawn)
        {
            Instantiate(alienPrefab, child.position, child.rotation);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
    
}
