using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    public Vector3 m_Axis = Vector3.up;
    public float m_Range = 0.3f;
    public float m_SmoothTime = 2.0f;
    private Vector3 m_OriginPosition;

    private void Start()
    {
        m_OriginPosition = transform.position;
    }

    private void Update()
    {
        float movement = m_Range * Mathf.Sin(Time.time * m_SmoothTime);
        transform.position = m_OriginPosition + m_Axis * movement;
    }
}
