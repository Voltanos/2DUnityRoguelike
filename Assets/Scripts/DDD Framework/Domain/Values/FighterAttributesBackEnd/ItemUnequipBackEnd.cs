using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This will unequip an old item.
/// </summary>
public class ItemUnequipBackEnd
{
    #region Public Methods

    public void Start(EquipmentSlotState slot, FighterAttributes fighter)
    {
        try
        {
            Unequip(slot, fighter);
        }

        catch (Exception ex)
        {
            StaticTrace.Log(ex.Message);
            StaticTrace.Log(ex.StackTrace);
        }
    }

    #endregion

    #region Private Methods

    private void Unequip(EquipmentSlotState slot, FighterAttributes fighter)
    {
        fighter.Equipment.Remove(slot);

        fighter.UpdateBonusAttributes();
    }

    #endregion
}
