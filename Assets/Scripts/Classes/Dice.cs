using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This is a list of methods used for random generation.
/// </summary>
public static class Dice
{
    #region Standard Dice

    /*
     * AJK:  Here is a list of default dice normally found in the real world.
     */

    public static int D2()
    {
        return RandomRoll(2);
    }

    public static int D4()
    {
        return RandomRoll(4);
    }

    public static int D6()
    {
        return RandomRoll(6);
    }

    public static int D8()
    {
        return RandomRoll(8);
    }

    public static int D10()
    {
        return RandomRoll(10);
    }

    public static int D12()
    {
        return RandomRoll(12);
    }

    public static int D20()
    {
        return RandomRoll(20);
    }

    public static int D100()
    {
        return RandomRoll(100);
    }

    /// <summary>
    /// This will return a value between 1 and y.
    /// </summary>
    public static int DY(int y)
    {
        return RandomRoll(y);
    }

    /// <summary>
    /// This will return the total between 1 and y, which
    /// is rolled x times.
    /// </summary>
    public static int XDY(int x, int y)
    {
        return MultiRandomRoll(y, x);
    }

    /// <summary>
    /// This will get a random value between x and y.
    /// </summary>
    public static int BetweenRange(int x, int y)
    {
        return RandomXAndY(x, y);
    }

    #endregion

    #region Private Methods

    private static int RandomRoll(int value)
    {
        return Convert.ToInt32(UnityEngine.Random.Range(1, value + 1));
    }

    private static int RandomXAndY(int x, int y)
    {
        return Convert.ToInt32(UnityEngine.Random.Range(x, y + 1));
    }

    private static int MultiRandomRoll(int value, int multiplier)
    {
        /////////////////////////////////////////////////////////
        //Local Variables

        int x = 0;
        int result = 0;

        /////////////////////////////////////////////////////////

        for (x = 0; x < multiplier; x += 1)
        {
            result += Convert.ToInt32(UnityEngine.Random.Range(1, value + 1));
        }

        return result;
    }

    #endregion
}
