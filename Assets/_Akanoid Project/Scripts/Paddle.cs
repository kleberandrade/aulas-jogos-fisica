using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float m_Speed = 10.0f;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal") * m_Speed * Time.deltaTime;
        transform.Translate(x, 0, 0);
    }
}
