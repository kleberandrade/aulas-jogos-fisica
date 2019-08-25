using UnityEngine;

public class BreakoutPaddle : MonoBehaviour
{
    // Velocidade do movimento
    public float m_Speed = 20.0f;
    private Rigidbody m_Body;

    private void Start()
    {
        m_Body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Recebe o entrada das setas direita e esquerda
        float horizontal = Input.GetAxis("Horizontal");

        // Cria um vetor aplicando a entrada no eixo X
        Vector3 movement = Vector3.zero;
        movement.x = horizontal * m_Speed * Time.fixedDeltaTime;

        // Move o corpo rigído com o vetor de entrada
        m_Body.MovePosition(m_Body.transform.position + movement);
    }
}
