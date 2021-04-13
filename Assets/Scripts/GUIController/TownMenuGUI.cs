using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// This will display the menu for the town.
/// </summary>
public class TownMenuGUI : MonoBehaviour
{
    #region Member Variables

    public GUIBox GuiBox;

    public GUIButton ToDungeonButton;
    public GUIButton LoadButton;

    #endregion

    #region Monobehavior Methods

    void OnGUI()
    {
        DrawMenuGUI();
    }

    #endregion

    #region Private Methods

    private void DrawMenuGUI()
    {
        GuiBox.Draw();

        if (ToDungeonButton.Draw() == true)
        {
            SceneManager.LoadScene(SceneState.DUNGEON_STATE);
        }

        if (LoadButton.Draw() == true)
        {
            SaveLoad.Load();
        }
    }

    #endregion
}
