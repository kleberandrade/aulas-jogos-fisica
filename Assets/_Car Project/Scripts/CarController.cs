using UnityEngine;

[RequireComponent(typeof(CarKinematics))]
public class CarController : MonoBehaviour
{
    private CarKinematics m_CarKinematics;

    private void Awake()
    {
        m_CarKinematics = GetComponent<CarKinematics>();
    }

    public void Update()
    {
        m_CarKinematics.Horizontal = Input.GetAxis("Horizontal");
        m_CarKinematics.Vertical = Input.GetAxis("Vertical");
        m_CarKinematics.Brake = Input.GetButton("Jump") ? 1.0f : 0.0f;
    }
}
