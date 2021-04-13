using UnityEngine;
using System.Collections;

/// <summary>
/// This will control what GUI views will be displayed to the user's screen.
/// </summary>
[System.Serializable]
public class MainGUIController : MonoBehaviour
{
    #region Member Variables

    private bool DrawInventoryGUI;
    private bool DrawCharacterSheetGUI;

    #endregion

    #region Properties

    public bool GetDrawInventoryGUI
    {
        get
        {
            return DrawInventoryGUI;
        }
    }

    public bool GetDrawCharacterSheetGUI
    {
        get
        {
            return DrawCharacterSheetGUI;
        }
    }

    #endregion

    #region Public Methods

    /*
     * AJK:  These methods will reset the GUI states for any other GameObjects,
     * and draw the one they were specifically called for.
     */

    public void SwitchCharacterSheet()
    {
        DrawCharacterSheetGUI = Switch(DrawCharacterSheetGUI);
    }

    public void SwitchInventory()
    {
        DrawInventoryGUI = Switch(DrawInventoryGUI);
    }

    #endregion

    #region Private Methods

    private bool Switch(bool value)
    {
        ResetGUIs();
        return SwitchGUIState(value);
    }

    private void ResetGUIs()
    {
        DrawInventoryGUI = false;
        DrawCharacterSheetGUI = false;
    }

    private bool SwitchGUIState(bool value)
    {
        if (value == false)
        {
            value = true;
        }

        else
        {
            value = false;
        }

        return value;
    }

    #endregion
}
