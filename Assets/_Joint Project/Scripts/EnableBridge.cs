using UnityEngine;

public class EnableBridge : MonoBehaviour
{
    [SerializeField]
    private HingeJoint[] m_Joints;

    [SerializeField]
    private KeyCode m_ActiveKey;

    [SerializeField]
    private float[] m_Targets;

    private int m_CurrentTarget;

    public void Update()
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
