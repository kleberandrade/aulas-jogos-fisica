using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBridge : MonoBehaviour
{
    public HingeJoint[] m_Joints;

    public KeyCode m_ActiveKey;

    public float[] m_Targets;

    private int m_CurrentTarget = 0;

    private void Update()
    {
        if (Input.GetKeyDown(m_ActiveKey))
        {
            foreach (HingeJoint joint in m_Joints)
            {
                JointSpring spring = joint.spring;
                spring.targetPosition = m_Targets[m_CurrentTarget];

                joint.spring = spring;
            }

            m_CurrentTarget = ++m_CurrentTarget % m_Targets.Length;
        }
    }
}
