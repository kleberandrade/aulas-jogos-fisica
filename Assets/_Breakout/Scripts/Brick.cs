using UnityEngine;
public class Brick : MonoBehaviour
{
    // Quantidade de vida do bloco
    private int m_Life;
    // Máximo de vida (colisões) que o bloco pode ter              
    public int m_MaxLife = 5;
    // Cor para vida igual 1
    public Color m_MinColor = Color.black;
    // Cor para o máximo de vida
    public Color m_MaxColor = Color.magenta;
    // Referência do componente de Render do objeto
    private Renderer m_Renderer;

    private void Start()
    {
        // Pega o componente de render
        m_Renderer = GetComponent<Renderer>();
        // Gera uma vida aleatória entre 1 e Máximo
        m_Life = Random.Range(1, m_MaxLife + 1);
        // Troca a cor
        ChangeColor();
    }

    // Função para trocar a cor de acordo com a vida
    private void ChangeColor()
    {
        // Define uma cor de acordo com a vida
        Color color = Color.Lerp(m_MinColor, m_MaxColor, (m_Life - 1.0f) / (m_MaxLife - 1.0f));
        // Troca a cor do material principal
        m_Renderer.material.SetColor("_Color", color); 
    }

    // Função executada quando existe uma colisão
    private void OnCollisionEnter(Collision other)
    {
        // Diminui a vida do tijo e destrói se for menor que 1
        if (m_Life-- < 1) Destroy(gameObject);
        // Troca a cor
        ChangeColor();
    }
}