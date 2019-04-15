using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    private PlayerMovement m_MovementScript;

    public void Awake()
    {
        m_MovementScript = GetComponent<PlayerMovement>();
    }

    public void Update()
    {
        m_MovementScript.Horizontal = Input.GetAxis("Horizontal");
        m_MovementScript.Vertical = Input.GetAxis("Vertical");
        m_MovementScript.Jump = Input.GetButtonDown("Fire1");
        m_MovementScript.Dash = Input.GetButtonDown("Fire2");
    }
}