using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private KeyCode m_KeyToDetonate = KeyCode.Space;

    private Explosion m_Explosion;

    public void Awake()
    {
        m_Explosion = GetComponent<Explosion>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(m_KeyToDetonate))
        {
            m_Explosion.Detonate();
            CameraShake.Instance.ShakeOnce(4f, 30.0f);
            Destroy(gameObject, 0.3f);
        }    
    }
}
