using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color m_MinColor;
    public Color m_MaxColor;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();

        float number = Random.Range(0.0f, 1.0f);
        Color color = Color.Lerp(m_MinColor, m_MaxColor, number);

        renderer.material.SetColor("_Color", color);
    }
}
