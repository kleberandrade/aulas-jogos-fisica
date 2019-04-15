using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private GameObject m_OtherPortal;

    [SerializeField]
    private float m_OffsetScale;

    [SerializeField]
    private Vector3 m_Direction = Vector3.forward;

    [SerializeField]
    private float m_ExpulsionForce = 5.0f;

    [SerializeField]
    private bool m_AccumulateForce;

    [SerializeField]
    private bool m_PortalOn = true;

    [SerializeField]
    private string[] m_Tags = { "Player" };

    public void OnTriggerEnter(Collider other)
    {
        if (!m_PortalOn)
        {
            return;
        }

        for (int i = 0; i < m_Tags.Length; i++)
        {
            if (other.CompareTag(m_Tags[i]))
            {
                Vector3 direction = m_OtherPortal.transform.TransformDirection(m_Direction);
                Vector3 offset = direction * m_OffsetScale;

                other.transform.position = m_OtherPortal.transform.position + offset;
                other.transform.rotation = Quaternion.LookRotation(direction);

                Rigidbody body = other.GetComponent<Rigidbody>();
                if (!m_AccumulateForce)
                {
                    body.velocity = Vector3.zero;
                }
                body.AddForce(direction * m_ExpulsionForce, ForceMode.VelocityChange);
            }
        }
    }
}