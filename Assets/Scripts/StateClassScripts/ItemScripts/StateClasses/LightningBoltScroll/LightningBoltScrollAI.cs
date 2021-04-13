using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This is the AI for a Lightning Bolt scroll.
/// </summary>
[System.Serializable]
public class LightningBoltScrollAI : AbstractItemAI
{
    #region Member Variables

    private int RANGE = 5;
    private int MIN_DAMAGE = 5;
    private int MAX_DAMAGE = 10;

    #endregion

    #region Member Methods

    override public void Enter(GameObject main)
    {
        this.ItemName = "LightningBoltScroll";

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
        GameObject closestMonster = null;
        GameObject player;

        MonsterController monsterController;

        int closestDistance = int.MaxValue;
        int monsterDistance;
        int damage;

        ///////////////////////////////////////        

        monsterController = GameObject.FindWithTag(TagKeys.MAIN_CONTROLLER_KEY).GetComponent<MonsterController>();

        player = GameObject.FindWithTag(TagKeys.PLAYER_KEY);

        foreach (GameObject monster in monsterController.GetMonsters())
        {
            monsterDistance = NPCMover.DistanceTo(player, monster);

            if ((monsterDistance <= RANGE) && (monsterDistance < closestDistance))
            {
                closestMonster = monster;
                closestDistance = monsterDistance;
            }
        }

        if (closestMonster == null)
        {
            messageWindow.GetComponent<MessageWindow>().AddText("The scroll does nothing but fizzles!");
        }

        else
        {
            damage = Dice.BetweenRange(MIN_DAMAGE, MAX_DAMAGE);

            messageWindow.GetComponent<MessageWindow>().AddText(String.Format("{0} is shocked for {1} damage!", closestMonster.name, damage));

            closestMonster.GetComponent<Fighter>().TakeDamage(damage);
        }

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
        /////////////////////////////////////////////////////////////
        //Local Variables

        GameObject messageWindow = GameObject.FindWithTag(TagKeys.MESSAGE_WINDOW_KEY);

        string message = "";

        /////////////////////////////////////////////////////////////

        message = String.Format("This item delivers {0} to {1} damage to the closest monster.", MIN_DAMAGE, MAX_DAMAGE);

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
