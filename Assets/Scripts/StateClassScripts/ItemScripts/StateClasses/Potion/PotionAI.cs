using UnityEngine;
using System;
using System.Collections;

/*
This is a generic potion that restores some health to target.
*/
[System.Serializable]
public class PotionAI : AbstractItemAI
{
    #region Member Variables

    private int MIN_HEAL = 5;
    private int MAX_HEAL = 10;

    #endregion

    #region Member Methods

    override public void Enter(GameObject main)
    {
        this.OnUseCheck = true;
        this.OnEquipCheck = false;
        this.OnUnequipCheck = false;
        this.OnDropCheck = true;
        this.OnTargetCheck = false;

        return;
    }

    override public void Exit(GameObject main)
    {
        return;
    }

    override public void OnUse(GameObject main, GameObject itemTarget)
    {
        ///////////////////////////////////////
        //Local Variables

        GameObject messageWindow = GameObject.FindWithTag(TagKeys.MESSAGE_WINDOW_KEY);
        
        int HPRestored = 0;

        ///////////////////////////////////////

        HPRestored = Dice.BetweenRange(MIN_HEAL, MAX_HEAL);

        itemTarget.GetComponent<Fighter>().RestoreHP(HPRestored);

        messageWindow.GetComponent<MessageWindow>().AddText(String.Format("{0} restored {1} HP!", itemTarget.name, HPRestored.ToString()));

        DestroyItem(main);
    }

    override public void OnEquip(GameObject main, GameObject itemTarget)
    {

    }

    override public void OnUnequip(GameObject main, GameObject itemTarget)
    {

    }

    override public void OnDrop(GameObject main, GameObject itemTarget)
    {
        DestroyItem(main);
    }

    public override void OnTarget(GameObject main, GameObject itemTarget)
    {

    }

    public override void OnExamine(GameObject main)
    {
        ///////////////////////////////////////////////////////
        //Local Variables

        GameObject messageWindow = GameObject.FindWithTag(TagKeys.MESSAGE_WINDOW_KEY);

        string message = "";

        ///////////////////////////////////////////////////////

        message = String.Format("Drinking this will restore somewhere between {0} and {1} HP.", MIN_HEAL, MAX_HEAL);

        messageWindow.GetComponent<MessageWindow>().AddText(message);
    }

    private void DestroyItem(GameObject main)
    {
        ///////////////////////////////////////
        //Local Variables

        GameObject mainController;

        ///////////////////////////////////////

        mainController = GameObject.FindWithTag(TagKeys.MAIN_CONTROLLER_KEY);

        mainController.GetComponent<MainInventory>().RemoveItem(main);
        UnityEngine.Object.Destroy(main);
    }

    #endregion
}
