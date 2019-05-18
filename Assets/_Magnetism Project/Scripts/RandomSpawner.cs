using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_ObjectPrefab;

    [SerializeField]
    private int m_ObjectsNumber;

    [SerializeField]
    private float m_Range;

    [SerializeField]
    private float m_MinObjectScale;

    [SerializeField]
    private float m_MaxObjectScale;

    private void Start()
    {
        for (int i = 0; i < m_ObjectsNumber; i++)
        {
            Vector3 position = Random.insideUnitSphere * m_Range;
            Quaternion rotation = Quaternion.Euler(Random.insideUnitSphere * 360.0f);
            GameObject go = Instantiate(m_ObjectPrefab, position, rotation);
            go.transform.localScale = Vector3.one * Random.Range(m_MinObjectScale, m_MaxObjectScale);
        }        
    }
}
