using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    List[] WaypointList;
    int max;
    int getNextWaypoint(){
        CarWaypoint car = GameObject.GetComponent("CarWaypoint") as CarWaypoint;
        if(car.currentWaypoint == (max-1)){
            return null;
        }
        else{
            return (car.currentWaypoint + 1);
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
