using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpringJoint))]
[RequireComponent(typeof(LineRenderer))]
public class Rope : MonoBehaviour
{
    [SerializeField]
    private Transform m_WhatTheRopeIsConnectedTo;

    [SerializeField]
    private Transform m_WhatIsHangingFromTheRope;

    private LineRenderer m_LineRenderer;

    public List<Vector3> m_AllRopeSections = new List<Vector3>();

    [SerializeField]
    private float m_RopeLength = 1f;

    [SerializeField]
    private float m_MinRopeLength = 1f;

    [SerializeField]
    private float m_MaxRopeLength = 20f;

    [SerializeField]
    private float m_LoadMass = 100f;

    [SerializeField]
    private float m_WinchSpeed = 2f;

    private SpringJoint springJoint;

    public void Start()
    {
        springJoint = m_WhatTheRopeIsConnectedTo.GetComponent<SpringJoint>();

        m_LineRenderer = GetComponent<LineRenderer>();

        UpdateSpring();

        m_WhatIsHangingFromTheRope.GetComponent<Rigidbody>().mass = m_LoadMass;
    }

    public void Update()
    {
        UpdateWinch();
        DisplayRope();
    }

    private void UpdateSpring()
    {
        float density = 7750f;

        float radius = 0.02f;

        float volume = Mathf.PI * radius * radius * m_RopeLength;

        float ropeMass = volume * density;

        ropeMass += m_LoadMass;
        float ropeForce = ropeMass * 9.81f;
        float kRope = ropeForce / 0.01f;

        springJoint.spring = kRope * 1.0f;
        springJoint.damper = kRope * 0.8f;

        springJoint.maxDistance = m_RopeLength;
    }

    private void DisplayRope()
    {
        float ropeWidth = 0.2f;

        m_LineRenderer.startWidth = ropeWidth;
        m_LineRenderer.endWidth = ropeWidth;

        Vector3 A = m_WhatTheRopeIsConnectedTo.position;
        Vector3 D = m_WhatIsHangingFromTheRope.position;
        Vector3 B = A + m_WhatTheRopeIsConnectedTo.up * (-(A - D).magnitude * 0.1f);
        Vector3 C = D + m_WhatIsHangingFromTheRope.up * ((A - D).magnitude * 0.5f);

        BezierCurve.GetBezierCurve(A, B, C, D, m_AllRopeSections);

        Vector3[] positions = new Vector3[m_AllRopeSections.Count];

        for (int i = 0; i < m_AllRopeSections.Count; i++)
        {
            positions[i] = m_AllRopeSections[i];
        }

        m_LineRenderer.positionCount = positions.Length;

        m_LineRenderer.SetPositions(positions);
    }
    private void UpdateWinch()
    {
        bool hasChangedRope = false;

        if (Input.GetKey(KeyCode.O) && m_RopeLength < m_MaxRopeLength)
        {
            m_RopeLength += m_WinchSpeed * Time.deltaTime;
            hasChangedRope = true;
        }
        else if (Input.GetKey(KeyCode.I) && m_RopeLength > m_MinRopeLength)
        {
            m_RopeLength -= m_WinchSpeed * Time.deltaTime;
            hasChangedRope = true;
        }

        if (hasChangedRope)
        {
            m_RopeLength = Mathf.Clamp(m_RopeLength, m_MinRopeLength, m_MaxRopeLength);
            UpdateSpring();
        }
    }
}