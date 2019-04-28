using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Abilities")]
    [SerializeField]
    private float m_MovementSpeed = 5f;

    [SerializeField]
    private float m_JumpForce = 2f;

    [SerializeField]
    private float m_DashSpeed = 5f;

    [SerializeField]
    private bool m_UseDoubleJump;

    private bool m_CanDoubleJump;

    [Header("Gravity")]
    [SerializeField]
    private bool m_UseGravityScale = true;

    [SerializeField]
    public float m_GravityScale = 1.0f;

    [Header("Ground Checker")]
    [SerializeField]
    public Transform m_GroundChecker;

    [SerializeField]
    private float m_GroundDistance = 0.2f;

    [SerializeField]
    public LayerMask m_GroundMask;

    [SerializeField]
    private ParticleSystem m_GroundParticle;

    public float Horizontal { get; set; }
    public float Vertical { get; set; }
    public bool Jump { get; set; }
    public bool Dash { get; set; }

    private bool m_IsGrounded;
    private Rigidbody m_Body;
    private Vector3 m_Movement;

    public void Awake()
    {
        m_Body = GetComponent<Rigidbody>();
    }

    public void DoJump()
    {
        Vector3 velocity = m_Body.velocity;
        velocity.y = 0.0f;
        m_Body.velocity = velocity;
        m_Body.AddForce(transform.up * m_JumpForce, ForceMode.Impulse);
    }

    public void Update()
    {
        m_Movement.x = Horizontal;
        m_Movement.z = Vertical;

        if (Jump)
        {
            if (m_IsGrounded)
            {
                DoJump();
                m_CanDoubleJump = true;
            }
            else
            {
                if (m_UseDoubleJump && m_CanDoubleJump)
                {
                    DoJump();
                    m_CanDoubleJump = false;
                }
            }
        }

        if (Dash)
        {
            m_Body.AddForce(transform.forward * m_DashSpeed, ForceMode.Impulse);
        }
    }

    public void FixedUpdate()
    {
        m_IsGrounded = Physics.CheckSphere(m_GroundChecker.position, m_GroundDistance, m_GroundMask, QueryTriggerInteraction.Ignore);

        m_Body.useGravity = !m_UseGravityScale;

        if (m_UseGravityScale)
        {
            Vector3 gravity = Physics.gravity * m_GravityScale;
            m_Body.AddForce(gravity, ForceMode.Acceleration);
        }

        m_Body.MovePosition(m_Body.position + m_Movement.normalized * m_MovementSpeed * Time.fixedDeltaTime);

        if (m_Movement.magnitude > 0.0f)
        {
            Quaternion angle = Quaternion.LookRotation(m_Movement);
            m_Body.MoveRotation(angle);
        }

        UpdateGroundParticle();
    }

    private void UpdateGroundParticle()
    {
        if (m_GroundParticle)
        {
            if (m_GroundParticle.isStopped)
            {
                m_GroundParticle.Play();
            }

            var emission = m_GroundParticle.emission;
            emission.enabled = m_IsGrounded && m_Movement.magnitude != 0;
        }
    }
}