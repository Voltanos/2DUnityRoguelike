using UnityEngine;
using System;
using System.Collections;

public class CharacterSheetController : MonoBehaviour
{
    #region Member Variables

    private GameObject MessageWindow;

    private Fighter PlayerFighter;

    private int LevelUpPoint;

    #endregion

    #region Properties

    public Fighter GetPlayerFighter
    {
        get
        {
            return PlayerFighter;
        }
    }

    public int GetLevelUpPoint
    {
        get
        {
            return LevelUpPoint;
        }
    }

    #endregion

    #region Monobehaviour Methods

    void Start()
    {
        PlayerFighter = GameObject.FindWithTag(TagKeys.PLAYER_KEY).GetComponent<Fighter>();

        MessageWindow = GameObject.FindWithTag(TagKeys.MESSAGE_WINDOW_KEY);
    }

    void Update()
    {
        LevelUpCheck();
    }

    #endregion

    #region Public Methods

    public int ToNextLevel()
    {
        ////////////////////////////////////////////////////////
        //Local Variables

        const int BASE_XP = 200;
        const int XP_PER_LEVEL = 150;

        int totalXPRequired = 0;

        ////////////////////////////////////////////////////////

        totalXPRequired = BASE_XP + (XP_PER_LEVEL * PlayerFighter.Attributes.XPLevel);

        return totalXPRequired;
    }

    public void LevelUpHP()
    {
        ///////////////////////////////////////////////////
        //Local Variables

        const int MIN = 15;
        const int MAX = 25;

        int bonus = 0;

        ///////////////////////////////////////////////////

        if (CanLevelUp() == false)
        {
            return;
        }

        bonus = Dice.BetweenRange(MIN, MAX);

        PlayerFighter.Attributes.BaseMaxHP += bonus;
        PlayerFighter.Attributes.CurrentHP += bonus;

        MessageWindow.GetComponent<MessageWindow>().AddText(String.Format("You gained {0} HP!", bonus));
    }

    public void LevelUpPower()
    {
        ///////////////////////////////////////////////////
        //Local Variables

        const int MIN = 1;
        const int MAX = 3;

        int bonus = 0;

        ///////////////////////////////////////////////////

        if (CanLevelUp() == false)
        {
            return;
        }

        bonus = Dice.BetweenRange(MIN, MAX);

        PlayerFighter.Attributes.BasePower += bonus;

        MessageWindow.GetComponent<MessageWindow>().AddText(String.Format("You gained {0} Power!", bonus));
    }

    public void LevelUpDefense()
    {
        ///////////////////////////////////////////////////
        //Local Variables

        const int MIN = 1;
        const int MAX = 3;

        int bonus = 0;

        ///////////////////////////////////////////////////

        if (CanLevelUp() == false)
        {
            return;
        }

        bonus = Dice.BetweenRange(MIN, MAX);

        PlayerFighter.Attributes.BaseDefense += bonus;

        MessageWindow.GetComponent<MessageWindow>().AddText(String.Format("You gained {0} Defense!", bonus));
    }

    #endregion

    #region Private Methods

    private void LevelUpCheck()
    {
        ///////////////////////////////////////////////
        //Local Variables

        int toNextLevel = 0;

        ///////////////////////////////////////////////

        toNextLevel = ToNextLevel();

        if (PlayerFighter.Attributes.XP >= toNextLevel)
        {
            PlayerFighter.Attributes.XP -= toNextLevel;

            LevelUpPoint += 1;
            PlayerFighter.Attributes.XPLevel += 1;

            MessageWindow.GetComponent<MessageWindow>().AddText(String.Format("Your battle skills grow stronger!  You reached level {0}!", PlayerFighter.Attributes.XPLevel));
        }
    }

    private Boolean CanLevelUp()
    {
        if (LevelUpPoint > 0)
        {
            LevelUpPoint -= 1;

            return true;
        }

        return false;
    }

    #endregion
}
