using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float TimeBetweenSpawn;
    public Transform[] SpawnPositions;
    public CarWaypoint CarPrefab;
    public float CarTimer;

    public WaypointManager manager;

 //   public WaypointManager m_waypointManager;

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
        c.m_WaypointManager = manager;
//        CarWaypoint carwaypoint = c.GetComponent(typeof(CarWaypoint)) as CarWaypoint;
//        carwaypoint.m_WaypointManager = m_waypointManager;        
    }
}
