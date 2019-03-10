using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidStartBall : MonoBehaviour
{
    public float m_Speed = 500;

    private void Start()
    {
        float z = 1;
        float x = Random.Range(-1.0f, 1.0f);
        Vector3 force = new Vector3(x, 0, z) * m_Speed;
        GetComponent<Rigidbody>().AddForce(force);
    }

}
