using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_ObjectPrefab;

    [SerializeField]
    private int m_ObjectsNumber;

    [SerializeField]
    private float m_Range;

    private void Start()
    {
        for (int i = 0; i < m_ObjectsNumber; i++)
        {
            Vector3 position = Random.insideUnitSphere * m_Range;
            Quaternion rotation = Quaternion.Euler(Random.insideUnitSphere * 360.0f);
            Instantiate(m_ObjectPrefab, position, rotation);
        }        
    }
}
