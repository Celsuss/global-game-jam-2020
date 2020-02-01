using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

    public struct RigidbodyRoot {
        public Rigidbody Body;
        public Quaternion Rotation;
        public Vector3 Position;
    }

    public int Health;
    public int MaxHealth;

    public bool IsAlive {
        get {
            return Health > 0;
        }
    }

    private List<RigidbodyRoot> Rigidbodies;


    public void TakeDamage() {
        if (!IsAlive)
            return;

        Health--;
        if (Health <= 0) {
            Destroy();
        }
    }

    void Start() {
        Rigidbodies = new List<RigidbodyRoot>();
        foreach(var body in GetComponentsInChildren<Rigidbody>()) {
            var x = new RigidbodyRoot() {
                Body = body,
                Rotation = body.rotation,
                Position = body.position
            };
            Rigidbodies.Add(x);
            body.isKinematic = true;
        }
    }

    public void Destroy() {
        foreach(var body in Rigidbodies) {
            body.Body.isKinematic = false;
        }
    }

    public void Repair() {
        foreach(var body in Rigidbodies) {
            body.Body.MovePosition(body.Position);
            body.Body.MoveRotation(body.Rotation);
            body.Body.angularVelocity = Vector3.zero;
            body.Body.velocity = Vector3.zero;
            body.Body.isKinematic = true;
        }
        Health = MaxHealth;
    }

    void Update() {
        
    }
}
