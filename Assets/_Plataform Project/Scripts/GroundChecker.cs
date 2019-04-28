using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem m_DustParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (m_DustParticle)
        {
            var emission = m_DustParticle.emission;
            emission.rateOverDistanceMultiplier = 1.0f;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (m_DustParticle)
        {
            var emission = m_DustParticle.emission;
            emission.rateOverDistanceMultiplier = 0.0f;
        }
    }
}
