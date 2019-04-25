using UnityEngine;

public class CarKinematics : MonoBehaviour
{
    public float Horizontal { get; set; }
    public float Vertical { get; set; }
    public bool Brake { get; set; }

    [Header("Wheel Colliders")]
    [SerializeField]
    private WheelCollider m_WheelColliderFL;

    [SerializeField]    
    private WheelCollider m_WheelColliderFR;

    [SerializeField]
    private WheelCollider m_WheelColliderRL;

    [SerializeField]
    private WheelCollider m_WheelColliderRR;

    [Header("Wheel Meshes")]
    [SerializeField]
    private Transform m_WheelFL;

    [SerializeField]
    private Transform m_WheelFR;

    [SerializeField]
    private Transform m_WheelRL;

    [SerializeField]
    private Transform m_WheelRR;

    [Header("Steering")]
    [SerializeField]
    private float m_MinSteeringAngle = 15.0f;
    [SerializeField]
    private float m_MaxSteeringAngle = 25.0f;
    [SerializeField]
    private float m_MaxSpeedToSteeringAngle = 60.0f;
    [SerializeField]
    private float m_SmoothSteeringAngle = 10.0f;
    [SerializeField]
    private bool m_UseStabilityCurves = true;

    [Header("Physics")]
    [SerializeField]
    private Transform m_CenterOfGravity;
    [SerializeField]
    private float m_MaxMotorTorque = 1500.0f;
    [SerializeField]
    private float m_MaxReverseTorque = 300.0f;
    [SerializeField]
    private float m_MaxDecelerationForce = 200.0f;
    [SerializeField]
    private float m_BrakeTorque = 3000.0f;

    [Header("Drive Modes")]
    [SerializeField]
    private DriveMode m_DriveMode = DriveMode.All;

    public enum DriveMode { Front, Rear, All };

    [SerializeField]
    private SpeedMode m_SpeedMode = SpeedMode.KilometersPerHour;

    public enum SpeedMode { MetersPerSecond, KilometersPerHour, MilesPerHour };

    private Rigidbody m_Rigidbody;

    public bool IsReverse => m_WheelColliderRL.rpm < 0.0f && m_WheelColliderRR.rpm < 0.0f;

    public void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.centerOfMass = m_CenterOfGravity.localPosition;
    }

    public void FixedUpdate()
    {
        Steer();
        Accelerate();
        Braking();
        Deceleration();
        UpdateWheelPoses();
    }

    public void Steer()
    {
        float steeringAngle = 0.0f;
        if (m_UseStabilityCurves)
        {
            float speedFactor = GetSpeed() / m_MaxSpeedToSteeringAngle;
            steeringAngle = Mathf.Lerp(m_MaxSteeringAngle, m_MinSteeringAngle, speedFactor) * Horizontal;
        }
        else
        {
            steeringAngle = m_MaxSteeringAngle * Horizontal;
        }

        m_WheelColliderFL.steerAngle = Mathf.Lerp(m_WheelColliderFL.steerAngle, steeringAngle, Time.deltaTime * m_SmoothSteeringAngle);
        m_WheelColliderFR.steerAngle = Mathf.Lerp(m_WheelColliderFR.steerAngle, steeringAngle, Time.deltaTime * m_SmoothSteeringAngle); ;
    }

    private void Accelerate()
    {
        float motorTorque = Vertical >= 0.0f ? Vertical * m_MaxMotorTorque : Vertical * m_MaxReverseTorque;

        m_WheelColliderFL.motorTorque = m_DriveMode == DriveMode.Rear ? 0 : motorTorque;
        m_WheelColliderFR.motorTorque = m_DriveMode == DriveMode.Rear ? 0 : motorTorque;
        m_WheelColliderRL.motorTorque = m_DriveMode == DriveMode.Front ? 0 : motorTorque;
        m_WheelColliderRR.motorTorque = m_DriveMode == DriveMode.Front ? 0 : motorTorque;
    }

    private void Deceleration()
    {
        float motorTorque = Vertical * m_MaxDecelerationForce;

        if (motorTorque == 0.0f && !Brake)
        {
            m_WheelColliderFL.brakeTorque = m_MaxDecelerationForce;
            m_WheelColliderFR.brakeTorque = m_MaxDecelerationForce;
            m_WheelColliderRL.brakeTorque = m_MaxDecelerationForce;
            m_WheelColliderRR.brakeTorque = m_MaxDecelerationForce;
        }
    }

    private void Braking()
    {
        float brakeTorque = Brake ? m_BrakeTorque : 0.0f;

        m_WheelColliderFL.brakeTorque = brakeTorque;
        m_WheelColliderFR.brakeTorque = brakeTorque;
        m_WheelColliderRL.brakeTorque = brakeTorque;
        m_WheelColliderRR.brakeTorque = brakeTorque;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(m_WheelColliderFL, m_WheelFL);
        UpdateWheelPose(m_WheelColliderFR, m_WheelFR);
        UpdateWheelPose(m_WheelColliderRL, m_WheelRL);
        UpdateWheelPose(m_WheelColliderRR, m_WheelRR);
    }

    private void UpdateWheelPose(WheelCollider wheelCollider, Transform wheel)
    {
        Vector3 position = wheel.position;
        Quaternion rotation = wheel.rotation;

        wheelCollider.GetWorldPose(out position, out rotation);

        rotation = rotation * Quaternion.Euler(new Vector3(0, 0, 90));
        wheel.rotation = rotation;
        wheel.position = position;
    }

    public float GetSpeed()
    {
        switch (m_SpeedMode)
        {
            case SpeedMode.MetersPerSecond:
                return m_Rigidbody.velocity.magnitude;
            case SpeedMode.KilometersPerHour:
                return m_Rigidbody.velocity.magnitude * 3.6f;
            case SpeedMode.MilesPerHour:
                return m_Rigidbody.velocity.magnitude * 2.237f;
            default:
                return m_Rigidbody.velocity.magnitude;
        }
    }
}
