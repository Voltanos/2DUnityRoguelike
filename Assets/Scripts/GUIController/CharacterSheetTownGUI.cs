using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// This will display XP level and experience points of the character in town.  Along with
/// number of items in inventory.
/// </summary>
public class CharacterSheetTownGUI : MonoBehaviour
{
    #region Member Variables

    public GUIBox guiBox;

    public GUILabel XPLevel;
    public GUILabel TotalXP;
    public GUILabel TotalItemCount;

    #endregion

    #region MonoBehaviour Methods

    void Update()
    {
        try
        {
            UpdateLabels();
        }

        catch (Exception ex)
        {
            StaticTrace.ExceptionLog(ex.Message, ex.StackTrace);
        }
    }

    void OnGUI()
    {
        try
        {
            DrawLabels();
        }

        catch (Exception ex)
        {
            StaticTrace.ExceptionLog(ex.Message, ex.StackTrace);
        }
    }

    #endregion

    #region Member Methods

    private void UpdateLabels()
    {
        ////////////////////////////////////
        //Local Variables

        const string XP_LEVEL_LABEL = "XP Level:  {0}";
        const string CURRENT_XP_LABEL = "Current XP:  {0}";
        const string NUMBER_OF_ITEMS = "Total Items:  {0}";

        FighterAttributes playerFighter;

        ////////////////////////////////////

        playerFighter = ModelControl.GetPlayerAttributesFromModel();

        XPLevel.Content.text = string.Format(XP_LEVEL_LABEL, playerFighter.XPLevel.ToString());
        TotalXP.Content.text = string.Format(CURRENT_XP_LABEL, playerFighter.XP.ToString());
        TotalItemCount.Content.text = string.Format(NUMBER_OF_ITEMS, ModelControl.GetItemListFromModel().Count);
    }

    private void DrawLabels()
    {
        guiBox.Draw();

        XPLevel.Draw();
        TotalXP.Draw();
        TotalItemCount.Draw();
    }

    #endregion
}
