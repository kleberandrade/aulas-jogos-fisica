using UnityEngine;

[RequireComponent(typeof(CarKinematics))]
public class CarController : MonoBehaviour
{
    private CarKinematics m_CarKinematics;

    [Header("Player Input Names")]
    public string m_HorizontaAxisName = "Horizontal";
    public string m_VerticalAxisName = "Vertical";
    public string m_BrakeButtonName = "Brake";

    private void Awake()
    {
        m_CarKinematics = GetComponent<CarKinematics>();
    }

    public void Update()
    {
        m_CarKinematics.Horizontal = Input.GetAxis(m_HorizontaAxisName);
        m_CarKinematics.Vertical = Input.GetAxis(m_VerticalAxisName);
        m_CarKinematics.Brake = Input.GetButton(m_BrakeButtonName);
    }
}
