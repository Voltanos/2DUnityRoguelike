using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This is the starting state of all NPCs, until they see the player and go after them.
/// </summary>
[System.Serializable]
public class IdleAI : AbstractNPCAI
{
    #region Member Methods

    override public void Enter(GameObject main)
    {
        return;
    }

    override public void Execute(GameObject main)
    {
        ////////////////////////////////////////////
        //Local Variables

        GameObject player;

        MonsterAI myAI;

        ////////////////////////////////////////////

        player = GameObject.FindWithTag(TagKeys.PLAYER_KEY);
        myAI = main.GetComponent<MonsterAI>();

        if (NPCMover.DistanceTo(main, player) <= myAI.ViewRange)
        {
            myAI.ChangeState(new MeleeAttackAI());
        }
    }

    override public void Exit(GameObject main)
    {
        return;
    }

    #endregion
}
