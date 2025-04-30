using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    public float displayTime = 4.0f;
    VisualElement m_HealthBar;
    VisualElement m_NPCDialogue;
    float m_TimerDisplay;

    public static UIHandler instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_HealthBar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealthValue(1);
        m_NPCDialogue = uiDocument.rootVisualElement.Q<VisualElement>("NPCDialogue");
        m_NPCDialogue.style.display = DisplayStyle.None;
        m_TimerDisplay = -1.0f;

    }

    private void Update()
    {
        if(m_TimerDisplay > 0)
        {
            m_TimerDisplay -= Time.deltaTime;
            if(m_TimerDisplay < 0)
            {
                m_NPCDialogue.style.display = DisplayStyle.None;
            }
        }
    }

    public void SetHealthValue(float percentage)
    {
        m_HealthBar.style.width = Length.Percent(Mathf.Clamp(percentage, 0, 1.0f) * 100.0f);
    }

    public void DisplayDialogue()
    {
        m_NPCDialogue.style.display = DisplayStyle.Flex;
        m_TimerDisplay = displayTime;
    }
}
