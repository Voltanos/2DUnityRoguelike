using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This will make the NPC act confused for a certain duration.
/// </summary> 
public class ConfusionAI : AbstractNPCAI
{
    #region Member Variables

    private int ConfusionDuration;

    #endregion

    #region Member Methods

    override public void Enter(GameObject main)
    {
        ConfusionDuration = 5;

        return;
    }

    override public void Execute(GameObject main)
    {
        ////////////////////////////////////////////
        //Local Variables

        const int DO_NOTHING = 50;

        GameObject messageWindow;

        MonsterAI myAI;

        int random;
        int damage;

        ////////////////////////////////////////////

        messageWindow = GameObject.FindWithTag(TagKeys.MESSAGE_WINDOW_KEY);

        myAI = main.GetComponent<MonsterAI>();
        random = UnityEngine.Random.Range(1, 101);

        if (random < DO_NOTHING)
        {
            messageWindow.GetComponent<MessageWindow>().AddText(String.Format("{0} stares into nothing, drool drizzling from the corner of their mouth.", main.name));
        }

        else
        {
            damage = main.GetComponent<Fighter>().Attributes.TotalPower;

            messageWindow.GetComponent<MessageWindow>().AddText(String.Format("{0} starts to choke on its own saliva, delivering {1} damage!", main.name, damage));

            main.GetComponent<Fighter>().TakeDamage(damage);
        }

        ConfusionDuration -= 1;

        if (ConfusionDuration <= 0)
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

