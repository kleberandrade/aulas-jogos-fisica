using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float m_Force = 1000.0f;

    [SerializeField]
    private float m_Radius = 5.0f;

    [SerializeField]
    private float m_UpForce = 600.0f;

    [SerializeField]
    private LayerMask m_ColliderMask;

    public void Detonate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_Radius, m_ColliderMask);
        foreach (Collider collider in colliders)
        {
            Rigidbody body = collider.GetComponent<Rigidbody>();
            if (body == null)
            {
                continue;
            }

            body.isKinematic = false;
            body.AddExplosionForce(m_Force, transform.position, m_Radius, m_UpForce);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.1f);
        Gizmos.DrawSphere(transform.position, m_Radius);
    }
}
