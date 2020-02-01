using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWaypoint : MonoBehaviour
{
    int currentWaypoint;
    WaypointManager myWaypointManager;

    //When the Primitive collides with the walls, it will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Waypoint){
            currentWayPoint = myWaypointManager.getNextWaypoint();
        }
        if(currentWaypoint == NULL){
            //Desummon + PlayerScore+1
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
