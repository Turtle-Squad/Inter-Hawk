using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject drone;
    public bool stopSpawning;
    public float spawnTime;
    public float spawnDelay;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
	}
	
    public void SpawnObject()
    {
        Instantiate(drone, transform.position, transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
