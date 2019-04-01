using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    [SerializeField]
    private float m_Amplitude = 0.1f;

    [SerializeField]
    private float m_ScaleSpeed = 2.0f;

    private Vector3 m_StartScale;

    public void Start()
    {
        m_StartScale = transform.localScale;
    }

    public void Update()
    {
        transform.localScale = m_StartScale + Vector3.one * (Mathf.Sin(Time.time * m_ScaleSpeed) * m_Amplitude) ;
    }
}
