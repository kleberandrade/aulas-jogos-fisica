using UnityEngine;

public class Bomb : MonoBehaviour
{
    public KeyCode m_KeyToDetonate = KeyCode.Space;

    private Explosion m_Explosion;

    private void Awake()
    {
        m_Explosion = GetComponent<Explosion>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(m_KeyToDetonate))
        {
            m_Explosion.Detonate();
            Destroy(gameObject, 5.0f);
        }    
    }
}
