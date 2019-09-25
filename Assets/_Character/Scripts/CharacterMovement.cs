using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Input Name")]
    public string m_JumpButtonName = "Fire1";
    public string m_DashButtonName = "Fire2";
    public string m_HorizontalAxisName = "Horizontal";
    public string m_VerticalAxisName = "Vertical";

    [Header("Kinematic")]
    public float m_Speed = 5f;
    public float m_JumpHeight = 2f;
    public float m_DashDistance = 5f;
    public bool m_UseDoubleJump;

    [Header("Dynamic")]
    public float m_Gravity = -20.0f;
    public Vector3 m_Drag;

    [Header("Ground")]
    public Transform m_GroundChecker;
    public float m_GroundDistance = 0.1f;
    public LayerMask m_GroundLayer;

        
    private bool m_CanDoubleJump;
    private CharacterController m_Controller;
    private Vector3 m_Velocity;
    private bool m_IsGrounded = true;

    private void Awake()
    {
        m_Controller = GetComponent<CharacterController>();
    }

    private void DoJump(){
        m_Velocity.y += Mathf.Sqrt(m_JumpHeight * -2f * m_Gravity);
    }

    private void Update()
    {
        m_IsGrounded = Physics.CheckSphere(m_GroundChecker.position, m_GroundDistance, m_GroundLayer, QueryTriggerInteraction.Ignore);
        if (m_IsGrounded && m_Velocity.y < 0)
        {
            m_Velocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis(m_HorizontalAxisName), 0, Input.GetAxis(m_VerticalAxisName));
        m_Controller.Move(move * Time.deltaTime * m_Speed);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        if (Input.GetButtonDown(m_JumpButtonName))
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

        if (Input.GetButtonDown(m_DashButtonName))
        {
            m_Velocity += Vector3.Scale(transform.forward, m_DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * m_Drag.x + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * m_Drag.z + 1)) / -Time.deltaTime)));
        }


        m_Velocity.y += m_Gravity * Time.deltaTime;

        m_Velocity.x /= 1 + m_Drag.x * Time.deltaTime;
        m_Velocity.y /= 1 + m_Drag.y * Time.deltaTime;
        m_Velocity.z /= 1 + m_Drag.z * Time.deltaTime;

        m_Controller.Move(m_Velocity * Time.deltaTime);
    }
}