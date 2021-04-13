using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// All Item AIs start with this state.
/// </summary>
public class BlankItemAI : AbstractItemAI
{
    #region Member Methods

    override public void Enter(GameObject main)
    {
        this.OnUseCheck = false;
        this.OnEquipCheck = false;
        this.OnUnequipCheck = false;
        this.OnDropCheck = false;
        this.OnTargetCheck = false;

        return;
    }

    override public void Exit(GameObject main)
    {
        return;
    }

    override public void OnUse(GameObject main, GameObject itemTarget)
    {
        return;
    }

    override public void OnEquip(GameObject main, GameObject itemTarget)
    {
        return;
    }

    override public void OnUnequip(GameObject main, GameObject itemTarget)
    {
        return;
    }

    override public void OnDrop(GameObject main, GameObject itemTarget)
    {
        return;
    }

    public override void OnTarget(GameObject main, GameObject itemTarget)
    {
        return;
    }

    public override void OnExamine(GameObject main)
    {
        return;
    }

    #endregion
}
