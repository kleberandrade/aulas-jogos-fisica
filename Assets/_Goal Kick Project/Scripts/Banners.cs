using UnityEngine;

public class Banners : MonoBehaviour 
{
    [SerializeField]
    private Texture[] m_Banners;

    private Renderer[] m_Renderers;

    [SerializeField]
    private float m_TimeToChange = 5.0f;

    private int m_CurrentBanner;

    public void Start()
    {
        m_Renderers = GetComponentsInChildren<Renderer>();
        InvokeRepeating("ChangeTexture", 0, m_TimeToChange);
    }

    public void ChangeTexture()
    {
        m_CurrentBanner = ++m_CurrentBanner % m_Banners.Length;
        foreach (Renderer renderer in m_Renderers)
        {
            renderer.material.mainTexture = m_Banners[m_CurrentBanner];
        }
    }
}
