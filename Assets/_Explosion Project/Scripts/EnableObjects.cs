using UnityEngine;

public class EnableObjects : MonoBehaviour
{
    [SerializeField]
    private KeyCode m_KeyToEnableObjects = KeyCode.KeypadEnter;

    [SerializeField]
    private GameObject[] m_Objects;

    public void Update()
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
