using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BreakoutBall : MonoBehaviour
{
    // Força inicial da bola
    public float m_Force = 1000.0f;
    // Referência para o corpo rígido
    private Rigidbody m_Body;

    private void Start()
    {
        m_Body = GetComponent<Rigidbody>();
        // Define a direção inicial em Z (0, 0, 1)
        Vector3 direction = Vector3.forward;
        // Sorteia o valor de X para criar um angulo para frente
        direction.x = Random.Range(-0.8f, 0.8f);
        // Adiciona a força na bola
        m_Body.AddForce(direction * m_Force);
    }
}