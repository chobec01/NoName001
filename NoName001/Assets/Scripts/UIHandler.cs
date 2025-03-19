using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    VisualElement m_HealthBar;

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

    }
    public void SetHealthValue(float percentage)
    {
        m_HealthBar.style.width = Length.Percent(Mathf.Clamp(percentage, 0, 1.0f) * 100.0f);
    }
}
