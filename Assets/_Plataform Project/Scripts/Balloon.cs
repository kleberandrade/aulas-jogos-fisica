using UnityEngine;

public class Balloon : MonoBehaviour
{
    private float m_UpForce = 0.1f;

    private Rigidbody m_Body;

    private void Awake()
    {
        m_Body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 force = Physics.gravity * -1.0f + Vector3.up * m_UpForce;

        m_Body.AddForce(force, ForceMode.Force);
    }
}
