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

    public bool IsHit { get; private set; }

    public float Distance { get; private set; }

    public float Magnitude { get; private set; }

    public float Height { get; private set; }

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
        if (IsHit)
        {
            if (m_UseMagnus)
            {
                Vector3 magnusForce = Vector3.Cross(m_Rigidbody.angularVelocity, m_Rigidbody.velocity);
                m_Rigidbody.AddForce(m_MagnusConstant * magnusForce);
            }

            if (Time.frameCount > m_HitFrame + 10 && Magnitude < 0.25f)
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

    public void UpdateStats()
    {
        Distance = Vector3.Distance(transform.position, m_StartPosition);
        Magnitude = m_Rigidbody.velocity.magnitude;
        Height = Mathf.Max(transform.position.y, Height);
    }

    public void ResetBall(bool hit)
    {
        IsHit = hit;

        m_Rigidbody.velocity = Vector3.zero;
        m_Rigidbody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;

        m_StartPosition = transform.position;

        Distance = 0.0f;
        Magnitude = 0.0f;
        Height = 0.0f;
    }

    public void SetLaunchAngle(float launchAngle)
    {
        m_LaunchAngle = launchAngle;
        Vector3 rotation = transform.eulerAngles;
        rotation.x = -launchAngle;
        transform.eulerAngles = rotation;
    }

    public void Shot()
    {
        if (!IsHit)
        {
            m_HitFrame = Time.frameCount;
            ResetBall(true);
            m_Rigidbody.AddRelativeForce(Vector3.forward * m_Force, ForceMode.Impulse);
            m_Rigidbody.angularVelocity = new Vector3(m_BackSpin, m_SideSpin, 0);
        }
    }
}