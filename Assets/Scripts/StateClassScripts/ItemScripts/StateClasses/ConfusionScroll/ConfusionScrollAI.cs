using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This is the AI for a Confusion scroll.
/// </summary>
[System.Serializable]
public class ConfusionScrollAI : AbstractItemAI
{
    #region Member Variables

    const int SPELL_DISTANCE = 5;

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
        GameObject closestMonster = null;
        GameObject player;

        MonsterController monsterController;

        int closestDistance = int.MaxValue;
        int monsterDistance;

        ///////////////////////////////////////        

        monsterController = GameObject.FindWithTag(TagKeys.MAIN_CONTROLLER_KEY).GetComponent<MonsterController>();

        player = GameObject.FindWithTag(TagKeys.PLAYER_KEY);

        foreach (GameObject monster in monsterController.GetMonsters())
        {
            monsterDistance = NPCMover.DistanceTo(player, monster);

            if ((monsterDistance <= SPELL_DISTANCE) && (monsterDistance < closestDistance))
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
            closestMonster.GetComponent<MonsterAI>().ChangeState(new ConfusionAI());
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
        //////////////////////////////////////////////////
        //Local Variables

        GameObject messageWindow = GameObject.FindWithTag(TagKeys.MESSAGE_WINDOW_KEY);

        //////////////////////////////////////////////////

        messageWindow.GetComponent<MessageWindow>().AddText("The closest monster will become confused temporarily.");
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

