using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField]
    private int m_Life = 1;

    [SerializeField]
    private float m_MaxLife = 10;

    [SerializeField]
    private Color m_StartColor;

    [SerializeField]
    private Color m_EndColor;

    private Renderer m_Renderer;

    public void Start()
    {
        m_Life = Random.Range(0, (int)m_MaxLife);
        m_Renderer = GetComponent<Renderer>();
        Color color = Color.Lerp(m_StartColor, m_EndColor, m_Life / m_MaxLife);
        m_Renderer.material.SetColor("_Color", color);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (--m_Life <= 0)
        {
            Destroy(gameObject);
        }

        Color color = Color.Lerp(m_StartColor, m_EndColor, m_Life / m_MaxLife);
        m_Renderer.material.SetColor("_Color", color);
    }

}
