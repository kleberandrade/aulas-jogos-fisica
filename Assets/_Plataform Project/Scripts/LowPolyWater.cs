using UnityEngine;

public class LowPolyWater : MonoBehaviour
{
    public float m_WaveFrequency = 0.53f;
    public float m_WaveHeight = 0.48f;
    public float m_WaveLength = 0.71f;
    private Mesh m_Mesh;
    private Vector3 m_WaveSource = new Vector3(2.0f, 0.0f, 2.0f);
    private Vector3[] m_Vertices;

    public void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        MakeMeshLowPoly(mf);
    }

    private MeshFilter MakeMeshLowPoly(MeshFilter meshFilter)
    {
        m_Mesh = meshFilter.sharedMesh;
        Vector3[] oldVertices = m_Mesh.vertices;
        int[] triangles = m_Mesh.triangles;
        Vector3[] vertices = new Vector3[triangles.Length];

        for (int i = 0; i < triangles.Length; i++)
        {
            vertices[i] = oldVertices[triangles[i]];
            triangles[i] = i;
        }

        m_Mesh.vertices = vertices;
        m_Mesh.triangles = triangles;
        m_Mesh.RecalculateBounds();
        m_Mesh.RecalculateNormals();

        m_Vertices = m_Mesh.vertices;

        return meshFilter;
    }

    public void Update()
    {
        CalculateWave();
    }

    public void CalculateWave()
    {
        for (int i = 0; i < m_Vertices.Length; i++)
        {
            Vector3 v = m_Vertices[i];
            v.y = 0.0f;
            float dist = (Vector3.Distance(v, m_WaveSource) % m_WaveLength) / m_WaveLength;
            v.y = m_WaveHeight * Mathf.Sin(Time.time * Mathf.PI * 2.0f * m_WaveFrequency + (Mathf.PI * 2.0f * dist));
            m_Vertices[i] = v;
        }

        m_Mesh.vertices = m_Vertices;
        m_Mesh.RecalculateNormals();
        m_Mesh.MarkDynamic();

        GetComponent<MeshFilter>().mesh = m_Mesh;
    }
}