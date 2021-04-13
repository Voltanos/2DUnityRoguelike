using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This will add any XP value to the player's Fighter component.
/// </summary>
public static class AddXP
{
    public static void Start(int value)
    {
        try
        {
            AddValue(value);
        }

        catch (Exception ex)
        {
            StaticTrace.Log(ex.Message);
            StaticTrace.Log(ex.StackTrace);
        }
    }

    private static void AddValue(int value)
    {
        /////////////////////////////////////////////////////////////
        //Local Variables

        Fighter playerFighter;

        /////////////////////////////////////////////////////////////

        playerFighter = GameObject.FindWithTag(TagKeys.PLAYER_KEY).GetComponent<Fighter>();
        playerFighter.Attributes.XP += value;
    }
}
