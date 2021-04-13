using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This will traverse through all the equipped items and add them to the player's bonus
/// attributes.
/// </summary>
[System.Serializable]
public class UpdateBonusAttributeBackEnd
{
    #region Public Methods

    public void Start(FighterAttributes fighter)
    {
        try
        {
            UpdateBonus(fighter);
        }

        catch (Exception ex)
        {
            StaticTrace.Log(ex.Message);
            StaticTrace.Log(ex.StackTrace);
        }
    }

    #endregion

    #region Private Methods

    private void UpdateBonus(FighterAttributes fighter)
    {
        ResetBonuses(fighter);

        foreach (AbstractItemAI item in fighter.Equipment.Values)
        {
            fighter.BonusMaxHP += item.Attributes.BonusMaxHP;
            fighter.BonusDefense += item.Attributes.BonusDefense;
            fighter.BonusPower += item.Attributes.BonusPower;
        }
    }

    private void ResetBonuses(FighterAttributes fighter)
    {
        fighter.BonusMaxHP = 0;
        fighter.BonusDefense = 0;
        fighter.BonusPower = 0;

        if (fighter.CurrentHP > fighter.TotalMaxHP)
        {
            fighter.CurrentHP = fighter.TotalMaxHP;
        }
    }

    #endregion
}
