using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This will generate random attributes for a Shield item and return it.
/// </summary>
public static class NewShieldAttributes
{
    public static FighterAttributes Start()
    {
        try
        {
            return CreateAttributes();
        }

        catch (Exception ex)
        {
            StaticTrace.Log(ex.Message);
            StaticTrace.Log(ex.StackTrace);
            return new FighterAttributes();
        }
    }

    private static FighterAttributes CreateAttributes()
    {
        //////////////////////////////////////////////////////////
        //Local Variables

        FighterAttributes attributes = new FighterAttributes();

        //////////////////////////////////////////////////////////

        attributes.BonusDefense = Dice.D6();

        attributes.BonusMaxHP = NewBonusHP.Start();

        return attributes;
    }
}
