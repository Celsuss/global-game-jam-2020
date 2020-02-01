using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CarWaypoint : MonoBehaviour
{
    [SerializeField]
    WaypointManager m_WaypointManager;
    int m_CurrentWaypointIndex;
    Transform m_CurrentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentWaypointIndex = 0;
        m_CurrentWaypoint = null;
        Assert.IsNotNull(m_WaypointManager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Waypoint")
        {    
            Debug.Log("Waypoint reached");
            m_CurrentWaypoint = m_WaypointManager.GetNextWaypoint(m_CurrentWaypointIndex);
            m_CurrentWaypointIndex += 1;

            if(m_CurrentWaypoint == null)
            {
                // Kill the car
            }
        }
    }
}