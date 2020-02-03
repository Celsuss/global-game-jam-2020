using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destroyable : MonoBehaviour {

    public UnityEvent OnDestroyed;
    public UnityEvent OnRepaired;

    public struct RigidbodyRoot {
        public Rigidbody Body;
        public Quaternion Rotation;
        public Vector3 Position;
        public Material Material;
    }

    public int Health;
    public int MaxHealth;

    public Material DestroyedMaterial;

    public float RepairAmount;
    public string Name;

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
                Rotation = new Quaternion(body.rotation.x, body.rotation.y, body.rotation.z, body.rotation.w),
                Position = new Vector3(body.position.x, body.position.y, body.position.z),
                Material = body.GetComponent<MeshRenderer>().sharedMaterial
            };
            Rigidbodies.Add(x);
            body.isKinematic = true;
        }

        GetComponentInChildren<ParticleSystem>().Stop();

        if (!IsAlive)
            Destroy();
    }

    public void Destroy() {
        foreach(var body in Rigidbodies) {
            body.Body.isKinematic = false;
            body.Body.GetComponent<MeshRenderer>().sharedMaterial = DestroyedMaterial;
        }
        RepairAmount = 0;
        OnDestroyed.Invoke();
    }

    public void Repair(float Delta)
    {
        RepairAmount += Delta;
        if (RepairAmount >= 1)
            Repaired();
    }

    public void Repaired() {
        foreach(var body in Rigidbodies) {
            body.Body.isKinematic = true;
            body.Body.position = (body.Position);
            body.Body.rotation = (body.Rotation);
            body.Body.angularVelocity = Vector3.zero;
            body.Body.velocity = Vector3.zero;
            body.Body.GetComponent<MeshRenderer>().sharedMaterial = body.Material;
        }
        RepairAmount = 0;
        Health = Random.Range(MaxHealth/2, MaxHealth);
        OnRepaired.Invoke();
    }
}
