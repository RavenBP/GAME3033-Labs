using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuWidget : MenuWidget
{
    [SerializeField]
    private string StartMenuName = "Load Menu";
    [SerializeField]
    private string OptionsMenuName = "Options Menu";
    public void OpenStartMenu()
    {
        menuController.EnableMenu(StartMenuName);
    }

    public void OpenOptionsMenu()
    {
        menuController.EnableMenu(OptionsMenuName);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
