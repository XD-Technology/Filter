using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class MenuPanel 
{
    [SerializeField] private GameObject panel = null;
    [SerializeField] private Button button = null;

    public GameObject Panel => panel;
    public Button Button => button;
}

[Serializable]
public abstract class MenuPanelBase : MenuPanel
{
    public abstract void Initilize();
}
