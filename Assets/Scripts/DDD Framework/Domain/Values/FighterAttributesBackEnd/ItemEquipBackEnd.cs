using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This will equip a new item.
/// </summary>
[System.Serializable]
public class ItemEquipBackEnd
{
    #region Public Methods

    public void Start(AbstractItemAI item, FighterAttributes fighter)
    {
        try
        {
            Equip(item, fighter);
        }

        catch (Exception ex)
        {
            StaticTrace.Log(ex.Message);
            StaticTrace.Log(ex.StackTrace);
        }
    }

    #endregion

    #region Private Methods

    private void Equip(AbstractItemAI item, FighterAttributes fighter)
    {
        if (fighter.Equipment.ContainsKey(item.Slot) == true)
        {
            fighter.ItemUnequip(item.Slot);
        }

        fighter.Equipment.Add(item.Slot, item);

        fighter.UpdateBonusAttributes();
    }

    #endregion
}
