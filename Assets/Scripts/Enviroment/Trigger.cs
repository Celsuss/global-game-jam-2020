using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent TakeDamage;

    public void OnTriggerEnter(Collider other) {
        TakeDamage.Invoke();
    }
}
