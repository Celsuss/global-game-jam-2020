using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}

public class CarMovement : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    // public float maxSteeringAngle; // maximum steer angle the wheel can have
    public float rotationDamping = 6.0f;

    [SerializeField]
    Transform m_Target;

    int m_Steering;
    float m_Speed;

    // Start is called before the first frame update
    void Start()
    {
        m_Steering = 0;
        m_Speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Target == null){
            Destroy(gameObject);
            Debug.Log("No target");
            return;
        }

        // 1. Calculate direction to waypoint
        Vector3 target_dir = m_Target.position - transform.position;

        // float rotationDamping = 6.0f;
        Quaternion rotation = Quaternion.LookRotation(m_Target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationDamping * Time.deltaTime);
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * m_Speed;
        // float steering = maxSteeringAngle * m_Steering;

            
        foreach (AxleInfo axleInfo in axleInfos) {
            // if (axleInfo.steering) {
            //     axleInfo.leftWheel.steerAngle = steering;
            //     axleInfo.rightWheel.steerAngle = steering;
            // }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }
    }

    public void SetTarget(Transform target)
    {
        m_Target = target;
    }
}