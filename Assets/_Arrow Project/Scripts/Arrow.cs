using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float m_RotateSpeed = 300.0f;

    private Rigidbody m_Rigidbody;

    private bool m_HitSomething;

    public void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (!m_HitSomething)
        {
            transform.rotation = Quaternion.LookRotation(m_Rigidbody.velocity) 
                * Quaternion.Euler(Vector3.right * 90)
                * Quaternion.Euler(Vector3.up * Time.time * m_RotateSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Arrow"))
        {
            m_HitSomething = true;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
