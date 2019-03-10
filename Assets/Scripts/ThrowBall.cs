using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public float m_Force = 500.0f;
    public Vector3 m_Position = Vector3.up;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        //rb.AddForce(m_Position * m_Force);
        //rb.AddRelativeForce(m_Position * m_Force);

        Vector3 direction = rb.transform.position - m_Position;
        rb.AddForceAtPosition(direction.normalized * m_Force, m_Position);
    }
}
