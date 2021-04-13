using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This will perform all melee-attack actions for this NPC.
/// </summary>
[System.Serializable]
public class MeleeAttackAI : AbstractNPCAI
{
    #region Member Methods

    override public void Enter(GameObject main)
    {
        ///////////////////////////////////////////
        //Local Variables

        GameObject messageWindow;

        ///////////////////////////////////////////

        messageWindow = GameObject.FindWithTag(TagKeys.MESSAGE_WINDOW_KEY);

        messageWindow.GetComponent<MessageWindow>().AddText(main.name + " charges towards you!");
    }

    override public void Execute(GameObject main)
    {
        /////////////////////////////////////////////
        //Local Variables

        GameObject player;
        GameObject collidedObject;

        MonsterAI myAI;

        /////////////////////////////////////////////

        player = GameObject.FindWithTag(TagKeys.PLAYER_KEY);
        myAI = main.GetComponent<MonsterAI>();

        collidedObject = NPCMover.MoveTowards(main, player);

        if (collidedObject != null)
        {
            AttackCheck(main, collidedObject);
        }

        if (NPCMover.DistanceTo(main, player) > myAI.ViewRange)
        {
            myAI.ChangeState(new IdleAI());
        }
    }

    override public void Exit(GameObject main)
    {
        return;
    }

    private void AttackCheck(GameObject main, GameObject other)
    {
        if (other.GetComponent<Tile>().Type != TileType.TILE_PLAYER)
        {
            return;
        }

        Attack(main, other);
    }

    private void Attack(GameObject main, GameObject player)
    {
        ////////////////////////////////////////
        //Local Variables

        Fighter myFighter;

        ////////////////////////////////////////

        myFighter = main.GetComponent<Fighter>();
        myFighter.AttackTarget(player);
    }

    #endregion
}
