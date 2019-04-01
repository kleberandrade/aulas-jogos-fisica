using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    [SerializeField]
    private Rigidbody m_BallPrefab;

    [SerializeField]
    private float m_Force = 10.0f;

    private Camera m_Camera;

    public void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Rigidbody ball = Instantiate<Rigidbody>(m_BallPrefab);
            ball.transform.position = transform.position;
            ball.velocity = m_Camera.transform.rotation * Vector3.forward * m_Force;
        }
    }
}
