using UnityEngine;
using System;
using System.Text;
using System.Collections;

/// <summary>
/// This will generate a new message for examining an equipable item.
/// </summary>
public static class EquipmentExamineMessage
{
    public static string Start(FighterAttributes attributes)
    {
        try
        {
            return GetExamineMessage(attributes);
        }

        catch (Exception ex)
        {
            StaticTrace.Log(ex.Message);
            StaticTrace.Log(ex.StackTrace);
            return "Error in generating message.";
        }
    }

    private static string GetExamineMessage(FighterAttributes attributes)
    {
        /////////////////////////////////////////////////
        //Local Variables

        StringBuilder builder = new StringBuilder();

        /////////////////////////////////////////////////

        builder.Append("This item changes the player's following attributes:");
        builder.Append(Environment.NewLine);

        if (attributes.BonusMaxHP > 0)
        {
            builder.AppendFormat("Bonus HP:  +{0}", attributes.BonusMaxHP);
            builder.Append(Environment.NewLine);
        }

        if (attributes.BonusPower > 0)
        {
            builder.AppendFormat("Bonus Power:  +{0}", attributes.BonusPower);
            builder.Append(Environment.NewLine);
        }

        if (attributes.BonusDefense > 0)
        {
            builder.AppendFormat("Bonus Defense:  +{0}", attributes.BonusDefense);
        }

        return builder.ToString();
    }
}
