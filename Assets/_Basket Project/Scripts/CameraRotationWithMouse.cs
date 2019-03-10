using UnityEngine;

public class CameraRotationWithMouse : MonoBehaviour
{
    public float m_RotationSpeed = 5.0f;

    private Camera m_Camera;

    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * m_RotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * m_RotationSpeed;

        transform.localRotation = Quaternion.Euler(0, mouseX, 0) * transform.localRotation;
        m_Camera.transform.localRotation = Quaternion.Euler(-mouseY, 0, 0) * m_Camera.transform.localRotation;
    }
}