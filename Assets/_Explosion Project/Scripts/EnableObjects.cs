using UnityEngine;

public class EnableObjects : MonoBehaviour
{
    public KeyCode m_KeyToEnableObjects = KeyCode.KeypadEnter;

    public GameObject[] m_Objects;

    private void Update()
    {
        if (Input.GetKeyDown(m_KeyToEnableObjects))
        {
            foreach (GameObject go in m_Objects)
            {
                go.SetActive(true);
            }
        }
    }
}
