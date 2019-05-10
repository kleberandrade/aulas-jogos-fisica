using UnityEngine;

public class Magnetism : MonoBehaviour
{
    public enum MagnestimType { Repulsion = -1, None = 0, Attraction = 1 };

    [SerializeField]
    private MagnestimType m_Type = MagnestimType.None;

    public MagnestimType Type
    {
        get { return m_Type; }
        set { m_Type = value; }
    }

    [SerializeField]
    private Transform m_CenterPoint;

    [SerializeField]
    private float m_Radius;

    public float Radius
    {
        get { return m_Radius; }
        set { m_Radius = value; }
    }

    [SerializeField]
    private float m_Force;

    [SerializeField]
    private float m_StopRadius;

    [SerializeField]
    private LayerMask m_Layers;

    private Rigidbody m_Body;

    public void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(m_CenterPoint.position, m_Radius, m_Layers);

        float signal = (int)m_Type;

        foreach (var collider in colliders)
        {
            Rigidbody body = collider.GetComponent<Rigidbody>();

            if (!body)
            {
                continue;
            }

            Vector3 direction = m_CenterPoint.position - body.position;

            float distance = direction.magnitude;
            if (distance < m_StopRadius)
            {
                continue;
            }

            body.AddForce(direction.normalized * (m_Force / distance) * body.mass * Time.fixedDeltaTime * signal);
        }
    }
}