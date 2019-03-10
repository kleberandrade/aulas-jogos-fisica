using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int m_Life = 1;
    public float m_MaxLife = 10;

    public Color m_StartColor;
    public Color m_EndColor;

    private Renderer m_Renderer;

    private void Start()
    {
        m_Life = Random.Range(0, (int)m_MaxLife);
        m_Renderer = GetComponent<Renderer>();
        Color color = Color.Lerp(m_StartColor, m_EndColor, m_Life / m_MaxLife);
        m_Renderer.material.SetColor("_Color", color);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (--m_Life <= 0)
            Destroy(gameObject);

        Color color = Color.Lerp(m_StartColor, m_EndColor, m_Life / m_MaxLife);
        m_Renderer.material.SetColor("_Color", color);
    }

}
