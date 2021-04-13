using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This is used for validating data.
/// </summary>
public static class Validator
{
    /// <summary>
    /// This will check to see if target is near the player.
    /// </summary>
    public static bool TargetNearPlayer(GameObject target, int maxDistance)
    {
        //////////////////////////////////////////////////
        //Local Variables

        GameObject player;

        int distance;

        //////////////////////////////////////////////////

        player = GameObject.FindWithTag(TagKeys.PLAYER_KEY);

        distance = NPCMover.DistanceTo(player, target);

        if (distance <= maxDistance)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
