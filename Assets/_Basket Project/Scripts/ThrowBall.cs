using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public Rigidbody m_BallPrefab;
    public float m_Force = 10.0f;

    private Camera m_Camera;

    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }

    private void Update(){

        if (Input.GetButtonDown("Fire1")){
            Rigidbody ball = Instantiate<Rigidbody>(m_BallPrefab);
            ball.transform.position = transform.position;
            ball.velocity = m_Camera.transform.rotation * Vector3.forward * m_Force;
        }
    }
}
