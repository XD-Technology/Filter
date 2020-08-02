using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public MainPanel main;
    public SettingsPanel settings;
    public ShopPanel shop;

    [SerializeField] private List<MenuPanel> panels;
    [SerializeField] private MenuPanel currentPanel;

    private void Start()
    {
        panels = new List<MenuPanel>();

        main.Initilize();
        main.Button.onClick.AddListener(() => SwitchPanel(0));
        panels.Add(main);

        settings.Initilize();
        settings.Button.onClick.AddListener(() => SwitchPanel(1));
        panels.Add(settings);

        currentPanel = null;
        SwitchPanel(0);
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SwitchPanel(0);
            }
        }
    }

    public void SwitchPanel(int index)
    {
        Debug.Log(index);
        if (currentPanel != null) currentPanel.Panel.SetActive(false);
        panels[index].Panel.SetActive(true);
        currentPanel = panels[index];
    }
}
