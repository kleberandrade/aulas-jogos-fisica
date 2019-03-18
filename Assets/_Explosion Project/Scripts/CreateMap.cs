using System.Collections;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public GameObject[] m_MapObjectPrefab;
    public int m_MaxDepth;
    public int m_MaxLength;
    public float m_MaxHeight;

    private void Start()
    {
        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        for (int x = 0; x < m_MaxLength; x++)
        {
            for (int z = 0; z < m_MaxDepth; z++)
            {
                int r = Random.Range(0, m_MapObjectPrefab.Length);
                GameObject go = Instantiate(m_MapObjectPrefab[r]);
                go.transform.parent = transform;

                float y = Random.Range(-m_MaxHeight, m_MaxHeight);
                go.transform.position = new Vector3(x - m_MaxLength * 0.5f, y, z - m_MaxDepth * 0.5f);

                yield return null;
            }
        }
    }
}
