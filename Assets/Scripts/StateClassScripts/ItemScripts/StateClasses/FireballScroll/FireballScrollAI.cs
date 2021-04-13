using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This is the Fireball Scroll AI.
/// </summary>
[System.Serializable]
public class FireballScrollAI : AbstractItemAI
{
    #region Member Variables

    private int RANGE = 5;
    private int MIN_DAMAGE = 6;
    private int MAX_DAMAGE = 12;

    #endregion

    #region Member Methods

    override public void Enter(GameObject main)
    {
        this.OnUseCheck = true;
        this.OnEquipCheck = false;
        this.OnUnequipCheck = false;
        this.OnDropCheck = true;
        this.OnTargetCheck = true;

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

        GameObject targetControl;
        GameObject target;
        GameObject player;

        ///////////////////////////////////////

        player = GameObject.FindWithTag(TagKeys.PLAYER_KEY);

        player.GetComponent<PlayerActions>().IncrementAction();

        targetControl = Resources.Load("TargetControl") as GameObject;

        target = GameObject.Instantiate(targetControl) as GameObject;

        target.GetComponent<TargetController>().StartTarget(TargetingState.ITEM_TARGET, RANGE, main);
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
        ////////////////////////////////////////////
        //Local Variables

        GameObject messageWindow = GameObject.FindWithTag(TagKeys.MESSAGE_WINDOW_KEY);        

        int damage = 0;

        ////////////////////////////////////////////

        damage = Dice.BetweenRange(MIN_DAMAGE, MAX_DAMAGE);

        itemTarget.GetComponent<Fighter>().TakeDamage(damage);

        messageWindow.GetComponent<MessageWindow>().AddText(String.Format("{0} was burned for {1} damage!", itemTarget.name, damage.ToString()));

        DestroyItem(main);
    }

    public override void OnExamine(GameObject main)
    {
        /////////////////////////////////////////////////////////////
        //Local Variables

        GameObject messageWindow = GameObject.FindWithTag(TagKeys.MESSAGE_WINDOW_KEY);

        string message = "";

        /////////////////////////////////////////////////////////////

        message = String.Format("A target monster will take {0} to {1} damage.", MIN_DAMAGE, MAX_DAMAGE);

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

