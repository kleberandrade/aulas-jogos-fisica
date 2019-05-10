using UnityEngine;
using UnityEngine.UI;

public class MagnetismController : MonoBehaviour
{
    private Magnetism m_Magneto;

    [SerializeField]
    private float m_Step;

    [SerializeField]
    private Text m_Text;

    private void Awake()
    {
        m_Magneto = GetComponent<Magnetism>();
    }

    public void Update()
    {
        m_Text.text = $"Magnetism: {m_Magneto.Type.ToString()}";

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_Magneto.Type = Magnetism.MagnestimType.None;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_Magneto.Type = Magnetism.MagnestimType.Attraction;
        }
            
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            m_Magneto.Type = Magnetism.MagnestimType.Repulsion;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_Magneto.Radius += m_Step * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_Magneto.Radius -= m_Step * Time.deltaTime;
        }

        Vector3 scale = Vector3.one * m_Magneto.Radius * 0.5f;
        transform.localScale = scale;
    }
}
