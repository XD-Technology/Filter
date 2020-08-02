using System;
using UnityEngine.UI;

[Serializable]
public class MainPanel : MenuPanelBase
{
    public Button PlayButton;

    public override void Initilize()
    {
        PlayButton.onClick.RemoveAllListeners();
        PlayButton.onClick.AddListener(GameManager.LoadGame);
    }
}
