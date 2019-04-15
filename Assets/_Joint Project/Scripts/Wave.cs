using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField]
    private float m_SmoothTime;

    [SerializeField]
    private float m_Magnitude;

    private Vector3 m_OriginalPosition;

    public void Start()
    {
        m_OriginalPosition = transform.localPosition;
    }

    public void Update()
    {
        float y = m_Magnitude * Mathf.Sin(Time.time * m_SmoothTime);
        transform.localPosition = m_OriginalPosition + Vector3.up * y;
    }
}
