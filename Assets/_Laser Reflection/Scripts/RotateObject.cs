using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField]
    private float m_SpeedRotate;

    [SerializeField]
    private Vector3 m_MoveAxis = Vector3.forward;

    public void Update()
    {
        transform.Rotate(m_MoveAxis * m_SpeedRotate * Time.deltaTime);
    }
}
