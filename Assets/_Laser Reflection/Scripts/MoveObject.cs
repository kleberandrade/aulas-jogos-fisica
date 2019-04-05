using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField]
    private float m_SmoothTime;

    [SerializeField]
    private float m_Magnitude;

    [SerializeField]
    private Vector3 m_MoveAxis = Vector3.forward;

    private Vector3 m_OriginalPosition;

    public void Start()
    {
        m_OriginalPosition = transform.localPosition;
    }

    public void Update()
    {
        float movement = m_Magnitude * Mathf.Sin(Time.time * m_SmoothTime);
        transform.localPosition = m_OriginalPosition + m_MoveAxis * movement;
    }
}
