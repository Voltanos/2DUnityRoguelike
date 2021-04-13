using UnityEngine;
using System.Collections;

public class CharacterSheetGUI : MonoBehaviour
{
    #region Member Variables

    private CharacterSheetController Controller;

    private GUIController GUIController;

    public GUIBox guiBox;

    public GUIButton HPBtn;
    public GUIButton POWBtn;
    public GUIButton DEFBtn;

    public GUILabel HPLabel;
    public GUILabel POWLabel;
    public GUILabel DEFLabel;
    public GUILabel XPLevelLabel;
    public GUILabel CurrentXPLabel;
    public GUILabel NextXPLabel;
    public GUILabel AttributePointLabel;

    #endregion

    #region Monobehaviour Methods

    void Start()
    {
        Controller = GetComponent<CharacterSheetController>();

        GUIController = GetComponent<GUIController>();
    }

    void OnGUI()
    {
        CanDrawGUI();
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    private void CanDrawGUI()
    {
        /////////////////////////////////////////////////////
        //Local Variables

        bool drawGUI = false;

        /////////////////////////////////////////////////////

        drawGUI = GUIController.GetDrawCharacterSheetGUI;

        if (drawGUI == true)
        {
            DrawCharacterSheet();
        }
    }

    private void DrawCharacterSheet()
    {
        ///////////////////////////////////////////////////////
        //Local Variables

        Fighter playerFighter;

        ///////////////////////////////////////////////////////

        playerFighter = Controller.GetPlayerFighter;

        guiBox.Draw();

        HPLabel.Content.text = string.Format
            (
                "Max HP:  {0} + {1} = {2}",
                playerFighter.Attributes.BaseMaxHP.ToString(),
                playerFighter.Attributes.BonusMaxHP.ToString(),
                playerFighter.Attributes.TotalMaxHP.ToString()
            );
        HPLabel.Draw();

        POWLabel.Content.text = string.Format
            (
                "Power:  {0} + {1} = {2}",
                playerFighter.Attributes.BasePower.ToString(),
                playerFighter.Attributes.BonusPower.ToString(),
                playerFighter.Attributes.TotalPower.ToString()
            );
        POWLabel.Draw();

        DEFLabel.Content.text = string.Format
            (
                "Defense:  {0} + {1} = {2}",
                playerFighter.Attributes.BaseDefense.ToString(),
                playerFighter.Attributes.BonusDefense.ToString(),
                playerFighter.Attributes.TotalDefense.ToString()
            );
        DEFLabel.Draw();

        XPLevelLabel.Content.text =
            string.Format("XP Level:  {0}", playerFighter.Attributes.XPLevel.ToString());
        XPLevelLabel.Draw();

        CurrentXPLabel.Content.text =
            string.Format("Current XP:  {0}", playerFighter.Attributes.XP.ToString());
        CurrentXPLabel.Draw();

        NextXPLabel.Content.text =
            string.Format("To Next Level:  {0}", Controller.ToNextLevel().ToString());
        NextXPLabel.Draw();

        if (Controller.GetLevelUpPoint > 0)
        {
            DrawLevelUpGUI();
        }
    }

    private void DrawLevelUpGUI()
    {
        AttributePointLabel.Content.text =
            string.Format("Attribute Points:  {0}", Controller.GetLevelUpPoint.ToString());
        AttributePointLabel.Draw();

        if (HPBtn.Draw() == true)
        {
            Controller.LevelUpHP();
        }

        if (POWBtn.Draw() == true)
        {
            Controller.LevelUpPower();
        }

        if (DEFBtn.Draw() == true)
        {
            Controller.LevelUpDefense();
        }
    }

    #endregion
}
