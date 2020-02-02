using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CarWaypoint : MonoBehaviour
{
    public WaypointManager m_WaypointManager;
    int m_CurrentWaypointIndex;
    Transform m_CurrentWaypoint;
    CarMovement m_CarMovement;

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(m_WaypointManager);
        m_CarMovement = gameObject.GetComponent<CarMovement>();

        m_CurrentWaypointIndex = 0;
        UpdateTarget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("On Trigger");
        if(other.gameObject.tag == "Waypoint" && other.transform.position == m_CurrentWaypoint.position)
        {    
            Debug.Log("Waypoint reached");
            UpdateTarget();
        }
    }

    void UpdateTarget()
    {
        m_CurrentWaypoint = m_WaypointManager.GetNextWaypoint(m_CurrentWaypointIndex);
        m_CurrentWaypointIndex = m_CurrentWaypointIndex+1;

        if(m_CurrentWaypoint == null)
        {
            // Kill the car
            Debug.Log("STOP!");
        }

        m_CarMovement.SetTarget(m_CurrentWaypoint);
    }
}