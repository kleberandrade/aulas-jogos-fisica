using UnityEngine;

public class ArkanoidStartBall : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 500;

    public void Start()
    {
        float z = 1;
        float x = Random.Range(-1.0f, 1.0f);
        Vector3 force = new Vector3(x, 0, z) * m_Speed;
        GetComponent<Rigidbody>().AddForce(force);
    }

}
