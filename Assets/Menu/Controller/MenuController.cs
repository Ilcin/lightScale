using System;
using UnityEngine;
using UnityEngine.UIElements;

public static class MenuController
{
    #region general
    public static VisualElement root { get; set; }
    public static void NavigateTo(MenuPage dest)
    {
        Debug.Log($"Navigate to {dest}.");
        CloseAllPages();

        // open menu
        root.style.display = DisplayStyle.Flex;

        // open page
        switch (dest) {
            case MenuPage.Main:
                root.Q("MainMenu").style.display = DisplayStyle.Flex;
                break;
            case MenuPage.Settings:
                root.Q("SettingsMenu").style.display = DisplayStyle.Flex;
                break;
        }
    }

    private static void CloseAllPages()
    {
        foreach(var page in root.Children())
        {
            page.style.display = DisplayStyle.None;
        }
    }
    #endregion

    #region main
    public static void StartGame()
    {
        Debug.Log("Start Game.");

    }

    public static void OpenSettings()
    {
        Debug.Log("Open Settings.");
        NavigateTo(MenuPage.Settings);
    }

    public static void CloseMenu()
    {
        Debug.Log("Close Menu.");
        root.style.display = DisplayStyle.None;
    }

    public static void ExitGame()
    {
        Debug.Log("Exit Game.");
        Application.Quit();
    }
    #endregion

    #region settings
    public static void ToggleMusic()
    {
        Debug.Log("Toggle Music.");
    }
    public static void SettingsBack()
    {
        Debug.Log("Toggle Music.");
        NavigateTo(MenuPage.Main);
    }
    #endregion
}
