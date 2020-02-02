using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Trigger on collsion.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            // Kill player if collision with player
            Debug.Log("Player Hit!");
            FindObjectOfType<PlayerMovement>().Die();
        }
    }
}
