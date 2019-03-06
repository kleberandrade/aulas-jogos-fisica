using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float m_Force;

    private Rigidbody m_Rigibody;

    private void Awake()
    {
        m_Rigibody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = (position - Input.mousePosition).normalized;
        direction.y = 0.0f;
        m_Rigibody.AddForce((transform.forward + direction) * m_Force);
    }
}


