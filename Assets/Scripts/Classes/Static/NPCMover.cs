using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// This will control all the movement actions for NPCs.
/// </summary>
public static class NPCMover
{
    #region Public Methods

    public static GameObject MoveTowards(GameObject main, GameObject other)
    {
        ////////////////////////////////////
        //Local Variables

        List<Vector3> positionList;

        Vector3 closestPosition;

        ////////////////////////////////////

        positionList = GetNewPositionList(main);

        closestPosition = GetDirection(positionList, other.transform.position);

        return main.GetComponent<TileMove>().TryMove(closestPosition);
    }

    public static int DistanceTo(Vector3 main, Vector3 other)
    {
        /////////////////////////////////////////
        //Local Variables

        int dx = 0;
        int dy = 0;
        int roundedDistance = 0;

        double distance = 0.0;

        /////////////////////////////////////////

        dx = Convert.ToInt32(other.x - main.x);
        dy = Convert.ToInt32(other.y - main.y);

        distance = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
        roundedDistance = Convert.ToInt32(distance);
        return roundedDistance;
    }

    public static int DistanceTo(GameObject main, GameObject other)
    {
        /////////////////////////////////////////
        //Local Variables

        int dx = 0;
        int dy = 0;
        int roundedDistance = 0;

        double distance = 0.0;

        Vector3 myPos;
        Vector3 otherPos;

        /////////////////////////////////////////

        myPos = main.GetComponent<Transform>().position;
        otherPos = other.GetComponent<Transform>().position;

        dx = Convert.ToInt32(otherPos.x - myPos.x);
        dy = Convert.ToInt32(otherPos.y - myPos.y);

        distance = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
        roundedDistance = Convert.ToInt32(distance);
        return roundedDistance;
    }

    #endregion

    #region Private Methods

    private static List<Vector3> GetNewPositionList(GameObject main)
    {
        /////////////////////////////////////////////////
        //Local Variables        

        List<Vector3> positionList = new List<Vector3>();

        /////////////////////////////////////////////////

        positionList.Add(new Vector3(main.transform.position.x, main.transform.position.y + 1, 0.0f));
        positionList.Add(new Vector3(main.transform.position.x + 1, main.transform.position.y, 0.0f));
        positionList.Add(new Vector3(main.transform.position.x, main.transform.position.y - 1, 0.0f));
        positionList.Add(new Vector3(main.transform.position.x - 1, main.transform.position.y, 0.0f));

        return positionList;
    }

    private static Vector3 GetDirection(List<Vector3> positionList, Vector3 targetPosition)
    {
        ////////////////////////////////////////////////////////////
        //Local Variables

        int shortestDistance = int.MaxValue;
        int distance = 0;

        Vector3 closestPosition = new Vector3();

        ////////////////////////////////////////////////////////////

        foreach (Vector3 position in positionList)
        {
            distance = DistanceTo(position, targetPosition);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestPosition = position;
            }
        }

        return closestPosition;
    }

    #endregion
}
