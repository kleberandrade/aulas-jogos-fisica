using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    public float m_Amplitude = 0.1f;
    public float m_ScaleSpeed = 2.0f;

    private Vector3 m_StartScale;

    private void Start()
    {
        m_StartScale = transform.localScale;
    }

    private void Update()
    {
        transform.localScale = m_StartScale + Vector3.one * (Mathf.Sin(Time.time * m_ScaleSpeed) * m_Amplitude) ;
    }
}
