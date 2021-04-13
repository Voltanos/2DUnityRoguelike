using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This will create a random number for maximum spawns and return it.
/// </summary>
public static class MaxSpawnGenerator
{
    public static int Start(int maxSpawns)
    {
        try
        {
            return GetSpawns(maxSpawns);
        }

        catch (Exception ex)
        {
            StaticTrace.Log(ex.Message);
            StaticTrace.Log(ex.StackTrace);
            return maxSpawns;
        }
    }

    private static int GetSpawns(int maxSpawns)
    {
        //////////////////////////////////////////////////////////
        //Local Variables

        int dungeonLevel = 0;
        int randomM = 0;
        int customSpawn = 0;

        //////////////////////////////////////////////////////////        

        dungeonLevel = GameObject.FindWithTag(TagKeys.MAIN_CONTROLLER_KEY).GetComponent<MapController>().GetDungeonLevel;

        randomM = Dice.BetweenRange(1, dungeonLevel);

        customSpawn = (randomM * dungeonLevel) + maxSpawns;

        return customSpawn;
    }
}
