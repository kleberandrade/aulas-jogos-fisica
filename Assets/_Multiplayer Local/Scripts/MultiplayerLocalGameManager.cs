using System;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerLocalGameManager : MonoBehaviour
{
    [Header("UI (User Interface)")]
    [SerializeField]
    private Text m_SpeedTextP1;
    [SerializeField]
    private Text m_SpeedTextP2;
    [SerializeField]
    private Text m_TimeText;

    [Header("Veicles")]
    [SerializeField]
    private CarKinematics m_CarP1;
    [SerializeField]
    private CarKinematics m_CarP2;

    [Header("Gameplay")]
    [SerializeField]
    private float m_MaxTime = 180;

    private float m_StartTime;

    public void Start()
    {
        m_StartTime = Time.time;
    }

    public void UpdateUI()
    {
        m_SpeedTextP1.text = m_CarP1.GetSpeed().ToString("0");
        m_SpeedTextP2.text = m_CarP2.GetSpeed().ToString("0");
        m_TimeText.text = (m_MaxTime - (Time.time - m_StartTime)).ToString("0");
    }

    public void LateUpdate()
    {
        UpdateUI();
    }
}
