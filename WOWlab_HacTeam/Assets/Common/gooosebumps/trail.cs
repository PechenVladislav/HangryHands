using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trail : MonoBehaviour {

    public GameObject hand;
    public Transform spawnPoints;
    public float spawnTime;


    void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);

        // Spawn();
    }
	
	void Update () {
        
    }

    void Spawn()
    {
        Instantiate(hand, spawnPoints.position, spawnPoints.rotation);
    }
}
