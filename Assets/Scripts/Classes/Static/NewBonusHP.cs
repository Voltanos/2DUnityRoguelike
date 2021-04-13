using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This will determine if any bonus HP should be attached ot an item.
/// </summary>
public static class NewBonusHP
{
    public static int Start()
    {
        try
        {
            return GetBonusHP();
        }

        catch (Exception ex)
        {
            StaticTrace.Log(ex.Message);
            StaticTrace.Log(ex.StackTrace);
            return 0;
        }
    }

    private static int GetBonusHP()
    {
        //////////////////////////////////////////////////
        //Local Variables

        const int BONUS_HP_CHANCE = 25;
        const int MIN = 15;
        const int MAX = 25;

        int chanceForHPBonus = 0;
        int bonus = 0;

        //////////////////////////////////////////////////

        chanceForHPBonus = Dice.D100();

        if (chanceForHPBonus <= BONUS_HP_CHANCE)
        {
            bonus = Dice.BetweenRange(MIN, MAX);
        }

        return bonus;
    }
}
