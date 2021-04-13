using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This will display the main menu in the game.
/// </summary>
[System.Serializable]
public class GameMenuGUI : MonoBehaviour
{
    #region Member Variables

    public GUIBox GuiBox;

    public GUIButton MainMenuButton;
    public GUIButton SaveGameButton;

    public bool DrawGUI;

    #endregion

    #region Monobehaviour Methods

    void OnGUI()
    {
        DrawMenu();
    }

    #endregion

    #region Member Methods

    private void DrawMenu()
    {
        if (DrawGUI == true)
        {
            GuiBox.Draw();

            if (MainMenuButton.Draw() == true)
            {
                SceneManager.LoadScene(SceneState.TOWN_STATE);
            }

            if (SaveGameButton.Draw() == true)
            {
                SaveLoad.Save();
            }
        }
    }

    #endregion
}

