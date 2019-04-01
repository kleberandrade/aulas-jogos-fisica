using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    [SerializeField]
    private Rigidbody m_ArrowPrefab;

    [SerializeField]
    private Transform m_ArrowSpawn;

    [SerializeField]
    private float m_MinForce = 10.0f;

    [SerializeField]
    private float m_MaxForce = 50.0f;

    [SerializeField]
    private float m_TimeToMaxForce = 2.0f;

    [SerializeField]
    private float m_CurrentForce;

    private float m_ElapsedTime;

    public void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            m_CurrentForce = Mathf.Lerp(m_MinForce, m_MaxForce, m_ElapsedTime / m_TimeToMaxForce);
            m_ElapsedTime += Time.deltaTime;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            m_ElapsedTime = 0.0f;
            Rigidbody arrow = Instantiate<Rigidbody>(m_ArrowPrefab, m_ArrowSpawn.position, m_ArrowSpawn.rotation);
            arrow.AddForce(m_ArrowSpawn.up * m_CurrentForce, ForceMode.VelocityChange);
        }
    }
}
