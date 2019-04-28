using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField]
    private Transform m_RespawTarget;

    [SerializeField]
    private float m_RespawnTime = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(Respawn(other.transform));
        }
    }

    public IEnumerator Respawn(Transform player)
    {
        yield return new WaitForSeconds(m_RespawnTime);

        player.transform.position = m_RespawTarget.position;
    }
}
