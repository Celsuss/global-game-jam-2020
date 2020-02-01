using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    List<Waypoint> WaypointList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Waypoint getNextWaypoint(int currentWaypoint){
        if(currentWaypoint >= WaypointList.Count)
            return null;
        else
            return WaypointList[currentWaypoint+1];
    }
}
