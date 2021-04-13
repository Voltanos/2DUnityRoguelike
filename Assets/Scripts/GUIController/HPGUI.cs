using UnityEngine;
using System;
using System.Collections;
using System.Text;

/// <summary>
/// This will display the current and max HP of the player.
/// </summary>
[System.Serializable]
public class HPGUI : MonoBehaviour
{
    #region Member Variables

    public GUIBox guiBox;

    public GUILabel hpOutput;

    #endregion

    #region MonoBehaviour Methods

    // Update is called once per frame
    void Update()
    {
        UpdateHP();
    }

    void OnGUI()
    {
        DrawHP();
    }

    #endregion

    #region Member Methods

    private void UpdateHP()
    {
        //////////////////////////////////////////////////
        //Local Variables

        FighterAttributes playerFighter;

        string output;

        //////////////////////////////////////////////////

        playerFighter = ModelControl.GetPlayerAttributesFromModel();

        output = String.Format("HP:  {0}/{1}", playerFighter.CurrentHP.ToString(), playerFighter.TotalMaxHP.ToString());

        hpOutput.Content.text = output;
    }

    private void DrawHP()
    {
        guiBox.Draw();
        hpOutput.Draw();
    }

    #endregion
}
