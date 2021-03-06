﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float TimeBetweenSpawn;
    public Transform[] SpawnPositions;
    public GameObject CarPrefab;
    public float CarTimer;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCar", TimeBetweenSpawn, TimeBetweenSpawn);
        
    }

    // Update is called once per frame
    void SpawnCar()
    {
        var t = SpawnPositions[Random.Range(0, SpawnPositions.Length)];
        var c = Instantiate(CarPrefab, t.position, t.rotation);
        
    }
}
