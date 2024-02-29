using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnmanager : MonoBehaviour
{
    public GameObject water;
    private Vector3 spawnpos = new Vector3(-13.906f, 11.839f, -1);
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    void Start()
    {
        InvokeRepeating("spawnWater", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    

    void spawnWater()
    {
        Instantiate(water, spawnpos, water.transform.rotation);
        if(stopSpawning)
        {
            CancelInvoke("spawnWater");
        }
    }
}
