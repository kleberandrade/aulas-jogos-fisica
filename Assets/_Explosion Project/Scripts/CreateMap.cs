using System.Collections;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_MapObjectPrefab;

    [SerializeField]
    private int m_MaxDepth;

    [SerializeField]
    private int m_MaxLength;

    [SerializeField]
    private float m_MaxHeight;

    public void Start()
    {
        StartCoroutine(Create());
    }

    public IEnumerator Create()
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
