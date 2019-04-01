using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MagnusEffectBall : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    [Header("Shot")]
    [Range(0.0f, 360.0f)]
    [SerializeField]
    private float m_LaunchAngle;

    [SerializeField]
    private float m_Force;

    [SerializeField]
    private float m_BackSpin;

    [SerializeField]
    private float m_SideSpin;

    [Header("Magnus Effect")]
    [SerializeField]
    private bool m_UseMagnus;

    [SerializeField]
    private float m_MagnusConstant = 1.0f;

    [Header("Stats")]
    [SerializeField]
    private bool m_IsHit;

    private float m_Distance;

    private float m_Magnitude;

    private float m_Height;

    private long m_HitFrame;

    private Vector3 m_StartPosition;

    public void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shot();
        }
    }

    public void FixedUpdate()
    {
        if (m_IsHit)
        {
            if (m_UseMagnus)
            {
                Vector3 magnusForce = Vector3.Cross(m_Rigidbody.angularVelocity, m_Rigidbody.velocity);
                m_Rigidbody.AddForce(m_MagnusConstant * magnusForce);
            }

            if (Time.frameCount > m_HitFrame + 10 && m_Magnitude < 0.25f)
            {
                ResetBall(false);
            }

            UpdateStats();
        }
        else
        {
            SetLaunchAngle(m_LaunchAngle);
        }
    }

    private void UpdateStats()
    {
        m_Distance = Vector3.Distance(transform.position, m_StartPosition);
        m_Magnitude = m_Rigidbody.velocity.magnitude;
        m_Height = Mathf.Max(transform.position.y, m_Height);
    }

    private void ResetBall(bool hit)
    {
        m_IsHit = hit;

        m_Rigidbody.velocity = Vector3.zero;
        m_Rigidbody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;

        m_StartPosition = transform.position;
        m_Distance = m_Magnitude = m_Height = 0.0f;
    }

    public void SetLaunchAngle(float launchAngle)
    {
        m_LaunchAngle = launchAngle;

        Vector3 rotation = transform.eulerAngles;
        rotation.x = -launchAngle;
        transform.eulerAngles = rotation;
    }

    private void Shot()
    {
        if (!m_IsHit)
        {
            m_HitFrame = Time.frameCount;

            ResetBall(true);

            m_Rigidbody.AddRelativeForce(Vector3.forward * m_Force, ForceMode.Impulse);
            m_Rigidbody.angularVelocity = new Vector3(m_BackSpin, m_SideSpin, 0);
        }
    }
}