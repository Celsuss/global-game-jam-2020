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
            return null;

        return m_Waypoints[currentWaypointIndex+1]; 
    }
}
