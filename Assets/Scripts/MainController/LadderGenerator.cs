using UnityEngine;
using System.Collections;

[System.Serializable]
public class LadderGenerator : MonoBehaviour
{
    #region Member Variables

    public GameObject Ladder;

    private GameObject LadderInstance;

    private int roomIndex = 0;

    private bool LadderSpawned = false;

    #endregion

    #region Member Methods

    public void ResetLadder()
    {
        LadderSpawned = false;

        roomIndex = 0;

        GameObject.Destroy(LadderInstance);
    }

    public void LadderSpawnCheck(CustomRect room, int maxRooms)
    {
        if (SpawnLadder(maxRooms) == true)
        {
            CreateLadder(room);
        }
    }

    private bool SpawnLadder(int maxRooms)
    {
        /////////////////////////////////////////////
        //Local Variables

        bool result = false;

        int randomValue = 0;

        /////////////////////////////////////////////

        if (LadderSpawned == true)
        {
            result = false;
            return result;
        }

        randomValue = Random.Range(0, maxRooms);

        roomIndex += 1;

        if (randomValue <= roomIndex)
        {
            result = true;
        }

        return result;
    }

    private Point GetRandomSpotInRoom(CustomRect _room)
    {
        ///////////////////////////////////////
        //Local Variables

        Point randomPoint;

        int randomX = 0;
        int randomY = 0;

        ///////////////////////////////////////

        randomX = Random.Range(_room.x1, _room.x2);
        randomY = Random.Range(_room.y1, _room.y2);

        randomPoint = new Point(randomX, randomY);
        return randomPoint;
    }

    private void CreateLadder(CustomRect room)
    {
        ///////////////////////////////////////////
        //Local Variables

        Point randomPoint;

        ///////////////////////////////////////////

        randomPoint = GetRandomSpotInRoom(room);

        while (GetComponent<MapController>().IsBlocked(randomPoint) == true)
        {
            randomPoint = GetRandomSpotInRoom(room);
        }

        LadderInstance = Instantiate(Ladder) as GameObject;
        LadderInstance.GetComponent<TileMove>().SetTransform(randomPoint.x, randomPoint.y);

        LadderInstance.name = Ladder.name;

        LadderSpawned = true;
    }

    #endregion
}

