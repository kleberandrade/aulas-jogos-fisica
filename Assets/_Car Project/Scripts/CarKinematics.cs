using UnityEngine;

public class CarKinematics : MonoBehaviour
{
    public float Horizontal { get; set; }
    public float Vertical { get; set; }
    public float Brake { get; set; }

    [SerializeField]
    private Transform m_CenterOfGravity;

    [SerializeField]
    private WheelCollider m_WheelColliderFL, m_WheelColliderFR;

    [SerializeField]
    private WheelCollider m_WheelColliderRL, m_WheelColliderRR;

    [SerializeField]
    private Transform m_WheelFL, m_WheelFR;

    [SerializeField]
    private Transform m_WheelRL, m_WheelRR;
    

    [SerializeField]
    private float m_MaxSteeringAngle = 30.0f;

    [SerializeField]
    private float m_MotorForce = 50.0f;

    [SerializeField]
    private float m_BrakeTorque = 100.0f;

    public enum DriveMode {  Front, Rear, All };

    public DriveMode m_DriveMode = DriveMode.All;

    private Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void Start()
    {
        m_Rigidbody.centerOfMass = m_CenterOfGravity.localPosition;
    }

    public void FixedUpdate()
    {
        Steer();
        Accelerate();
        Braking();
        UpdateWheelPoses();
    }

    public void Steer()
    {
        float steeringAngle =  m_MaxSteeringAngle * Horizontal;

        m_WheelColliderFL.steerAngle = steeringAngle;
        m_WheelColliderFR.steerAngle = steeringAngle;
    }

    private void Accelerate()
    {
        m_WheelColliderFL.motorTorque = m_DriveMode == DriveMode.Rear ? 0 : Vertical * m_MotorForce;
        m_WheelColliderFR.motorTorque = m_DriveMode == DriveMode.Rear ? 0 : Vertical * m_MotorForce;
        m_WheelColliderRL.motorTorque = m_DriveMode == DriveMode.Front ? 0 : Vertical * m_MotorForce;
        m_WheelColliderRR.motorTorque = m_DriveMode == DriveMode.Front ? 0 : Vertical * m_MotorForce;
    }

    private void Braking()
    {
        m_WheelColliderFL.brakeTorque = m_BrakeTorque * Brake;
        m_WheelColliderFR.brakeTorque = m_BrakeTorque * Brake;
        m_WheelColliderRL.brakeTorque = m_BrakeTorque * Brake;
        m_WheelColliderRR.brakeTorque = m_BrakeTorque * Brake;
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
}
