using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private Transform[] m_WayPoints;

    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private float m_Radius = 1;

    [SerializeField]
    private float m_TimeToNextWayPoint;

    private bool m_Waiting;

    private int m_Index = 0;

    private int m_Step = 1;

    public void Update()
    {
        if (!m_Waiting)
        {
            if (Vector3.Distance(m_WayPoints[m_Index].position, transform.position) <= m_Radius)
            {
                m_Waiting = true;
                transform.position = m_WayPoints[m_Index].transform.position;
                Invoke("NextWayPoint", m_TimeToNextWayPoint);
            }

            transform.position = Vector3.MoveTowards(transform.position, m_WayPoints[m_Index].position, Time.deltaTime * m_Speed);
        }
    }

    private void NextWayPoint()
    {
        m_Index += m_Step;

        if (m_Index >= m_WayPoints.Length || m_Index < 0)
        {
            m_Step *= -1;
            m_Index += m_Step;
        }

        m_Waiting = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
