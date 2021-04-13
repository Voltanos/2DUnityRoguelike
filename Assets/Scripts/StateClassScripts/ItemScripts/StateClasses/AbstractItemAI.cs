using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// This abstract class will be the base for all AI-items.
/// </summary>
[System.Serializable]
public abstract class AbstractItemAI
{
    #region Member Variables

    public bool OnUseCheck;
    public bool OnEquipCheck;
    public bool OnUnequipCheck;
    public bool OnDropCheck;
    public bool OnTargetCheck;

    public EquipmentSlotState Slot = EquipmentSlotState.NOTHING;

    public FighterAttributes Attributes;

    public string ItemName;

    public DateTime TimeStamp;

    #endregion

    #region Member Methods

    abstract public void Enter(GameObject main);
    abstract public void Exit(GameObject main);
    abstract public void OnUse(GameObject main, GameObject itemTarget);
    abstract public void OnEquip(GameObject main, GameObject itemTarget);
    abstract public void OnUnequip(GameObject main, GameObject itemTarget);
    abstract public void OnDrop(GameObject main, GameObject itemTarget);
    abstract public void OnTarget(GameObject main, GameObject itemTarget);
    abstract public void OnExamine(GameObject main);

    #endregion
}