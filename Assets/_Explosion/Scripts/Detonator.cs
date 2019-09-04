using UnityEngine;

public class Detonator : MonoBehaviour
{
    public Explosion m_ExplosionScript;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            m_ExplosionScript.Explode();
            CameraShake.Instance.ShakeOnce(1.0f, 30.0f);
            Destroy(gameObject);
        }
    }
}