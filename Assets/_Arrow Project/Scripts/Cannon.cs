using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    private Transform m_Base;

    [SerializeField]
    private Transform m_Barrel;

    [SerializeField]
    private float m_Speed;
    
    public void Update()
    {
        float horiontal = Input.GetAxis("Horizontal") * m_Speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * m_Speed * Time.deltaTime;

        m_Base.Rotate(Vector3.up * horiontal, Space.Self);
        m_Barrel.Rotate(Vector3.forward * vertical, Space.Self);
    }
}
