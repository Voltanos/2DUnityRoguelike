using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This will hold all the main attributes for the "Fighter" component.
/// </summary>
[System.Serializable]
public class FighterAttributes
{
    #region Member Variables

    //XP
    public int XP;
    public int XPLevel;

    //Current HP
    public int CurrentHP;

    //Base
    public int BaseMaxHP;
    public int BaseDefense;
    public int BasePower;

    //Bonus
    public int BonusMaxHP;
    public int BonusDefense;
    public int BonusPower;

    //Equipment.
    public Dictionary<EquipmentSlotState, AbstractItemAI> Equipment;

    #endregion

    #region Properties

    public int TotalMaxHP
    {
        get
        {
            return BaseMaxHP + BonusMaxHP;
        }
    }

    public int TotalDefense
    {
        get
        {
            return BaseDefense + BonusDefense;
        }
    }

    public int TotalPower
    {
        get
        {
            return BasePower + BonusPower;
        }
    }

    #endregion

    #region Constructors

    public FighterAttributes()
    {
        this.XP = 0;
        this.XPLevel = 1;

        this.BaseMaxHP = 30;
        this.BonusMaxHP = 0;
        this.CurrentHP = this.TotalMaxHP;

        this.BaseDefense = 5;
        this.BonusDefense = 0;

        this.BasePower = 10;
        this.BonusPower = 0;

        this.Equipment = new Dictionary<EquipmentSlotState, AbstractItemAI>();
    }

    #endregion

    #region Public Methods

    public void ItemUnequip(EquipmentSlotState slot)
    {
        /////////////////////////////////////////////
        //Local Variables

        ItemUnequipBackEnd backend = new ItemUnequipBackEnd();

        /////////////////////////////////////////////

        backend.Start(slot, this);
    }

    public void ItemEquip(AbstractItemAI item)
    {
        /////////////////////////////////////////////
        //Local Variables

        ItemEquipBackEnd backend = new ItemEquipBackEnd();

        /////////////////////////////////////////////

        backend.Start(item, this);
    }

    public void UpdateBonusAttributes()
    {
        /////////////////////////////////////////////
        //Local Variables

        UpdateBonusAttributeBackEnd backend = new UpdateBonusAttributeBackEnd();

        /////////////////////////////////////////////

        backend.Start(this);
    }

    #endregion
}
