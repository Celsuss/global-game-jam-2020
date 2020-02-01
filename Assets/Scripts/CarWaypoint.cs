using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWaypoint : MonoBehaviour
{
    int m_CurrentWaypointIndex;
    WaypointManager m_WaypointManager;
    Waypoint m_CurrentWaypoint;

    //When the Primitive collides with the walls, it will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Waypoint"){
            m_CurrentWaypoint = m_WaypointManager.getNextWaypoint(m_CurrentWaypointIndex);

        }

        if(m_CurrentWaypoint == null){
            // Kill car and increase player score
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        m_CurrentWaypointIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
