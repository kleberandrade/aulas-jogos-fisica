using UnityEngine;
public class MapBuilder : MonoBehaviour
{
    public GameObject m_TilePrefab;
    public float m_MinHeight = 0.0f;
    public float m_MaxHeight = 0.05f;
    public int m_Size = 20;
    private void Start()
    {
        for (int z = 0; z < m_Size; z++)
        {
            for (int x = 0; x < m_Size; x++)
            {
                float height = Random.Range(m_MinHeight, m_MaxHeight);
                Vector3 position = new Vector3(x - m_Size * 0.5f, height, z - m_Size * 0.5f);

                GameObject tile = Instantiate(m_TilePrefab);
                tile.transform.parent = transform;
                tile.transform.position = position;
            }
        }
    }
}
