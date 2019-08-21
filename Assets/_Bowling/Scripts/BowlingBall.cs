using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    /* Variável que define a força da bola */ 
    public float m_Force;

    /* Variável para guardar a referência do corpo rigído da bola */
    private Rigidbody m_Rigidbody;

    public void Awake()
    {
        /* Guarda uma referência do componente Rigidbody */
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void OnMouseDown()
    {
        /* Detecta a posição da bola (mundo 3D) em relação a tela (2D) */
        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);

        /* Realiza um calculo vetorial (Bola - Mouse), para saber a direção do mouse em relação ao centro da bola normaliza o vetor para criar um vetor de tamanho 1  */
        Vector3 direction = (position - Input.mousePosition).normalized;

        /* Elimina a possibilidade da bola ir para cima */
        direction.y = 0.0f;

        /* Adiciona uma força na bola de acordo com a direção calculada */
        m_Rigidbody.AddForce(direction * m_Force);
        /* Destroy o script da bola para que o jogador não consiga ficar empurrando a bola */
        Destroy(this);
    }
}