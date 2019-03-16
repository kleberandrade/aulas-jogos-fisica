using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float m_Force = 1000.0f;
    public float m_Radius = 5.0f;
    public float m_UpForce = 600.0f;
    public LayerMask m_ColliderMask;

    public void Detonate()
    {
        Debug.Log("Detonate");
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_Radius, m_ColliderMask);
        foreach (Collider collider in colliders)
        {
            Rigidbody body = collider.GetComponent<Rigidbody>();
            if (body == null) continue;

            body.isKinematic = false;
            body.AddExplosionForce(m_Force, transform.position, m_Radius, m_UpForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.1f);
        Gizmos.DrawSphere(transform.position, m_Radius);
    }
}
