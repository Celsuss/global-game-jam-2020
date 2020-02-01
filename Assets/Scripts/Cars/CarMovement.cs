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
    public float maxSteeringAngle; // maximum steer angle the wheel can have

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

        target_dir.y = 0;
        Vector3 forward = transform.forward;
        forward.y = 0;

        float angle_between = Vector3.Angle(forward, target_dir);

        // 2. Get forward vector
        if(angle_between >= 5 && angle_between < 85){
            // Turn left
            Debug.Log("Turning left, angle: " + angle_between);
            m_Steering = -30;
        }
        else if(angle_between > 95){
            // Turn right
            m_Steering = 30;
            Debug.Log("Turning right, angle: " + angle_between);
        }
        else{
            // Debug.Log("Forward, angle: " + angle_between);
            m_Steering = 0;
        }
    }

    public void FixedUpdate()
    {
        float motor_input = maxMotorTorque * Input.GetAxis("Vertical");
        float steering_input = maxSteeringAngle * Input.GetAxis("Horizontal");
        // Debug.Log("Steering: " + steering_input);

        Debug.Log("Steering: " + m_Steering);

        float motor = maxMotorTorque * m_Speed;
        float steering = maxSteeringAngle * m_Steering;

        // motor = motor_input;
        // steering = steering_input;
            
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
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