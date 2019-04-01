using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    [SerializeField]
    private float m_Force;

    private Rigidbody m_Rigidbody;

    public void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void OnMouseDown()
    {
        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = (position - Input.mousePosition).normalized;
        direction.y = 0.0f;
        m_Rigidbody.AddForce((transform.forward + direction) * m_Force);
    }
}
