using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    [SerializeField]
    List<Transform> m_Waypoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetNextWaypoint(int currentWaypointIndex)
    {
        if(currentWaypointIndex >= m_Waypoints.Count)
        {
            Debug.Log("Can't find waypoint index: " + currentWaypointIndex);
            return null;
        }

        Debug.Log("Current waypoint index: " + currentWaypointIndex);
        return m_Waypoints[currentWaypointIndex]; 
    }
}
