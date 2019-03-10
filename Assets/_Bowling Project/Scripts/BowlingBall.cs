using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    public float m_Force;

    private Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = (position - Input.mousePosition).normalized;
        direction.y = 0.0f;
        m_Rigidbody.AddForce((transform.forward + direction) * m_Force);
    }
}
