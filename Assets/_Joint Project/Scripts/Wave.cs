using UnityEngine;

public class Wave : MonoBehaviour
{
    public float m_SmoothTime;

    public float m_Magnitude;

    private Vector3 m_OriginalPosition;

    private void Start()
    {
        m_OriginalPosition = transform.localPosition;
    }

    private void Update()
    {
        float y = m_Magnitude * Mathf.Sin(Time.time * m_SmoothTime) * Time.deltaTime;
        transform.localPosition = m_OriginalPosition + Vector3.up * y;
    }
}
