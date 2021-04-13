using UnityEngine;
using System.Collections;

/// <summary>
/// This will generate an item in the dungeon.
/// </summary>
public class ItemGenerator : MonoBehaviour
{
    #region Member Variables

    public GameObject[] Items;

    public int MaxNumOfItems = 5;

    public int SpawnRate = 50;

    private int MaxSpawns;

    #endregion

    #region Public Methods

    public void ItemSpawnCheck(CustomRect room)
    {
        if (SpawnItem() == true)
        {
            CreateItem(room);
        }
    }

    public void NewMaxSpawnCheck(int length)
    {
        if (length == 0)
        {
            MaxSpawns = MaxSpawnGenerator.Start(MaxNumOfItems);
        }
    }

    #endregion

    #region Private Methods

    private Point getRandomSpotInRoom(CustomRect room)
    {
        ///////////////////////////////////////
        //Local Variables

        Point randomPoint;

        int randomX = 0;
        int randomY = 0;

        ///////////////////////////////////////

        randomX = Random.Range(room.x1, room.x2);
        randomY = Random.Range(room.y1, room.y2);

        randomPoint = new Point(randomX, randomY);
        return randomPoint;
    }

    private void CreateItem(CustomRect room)
    {
        ////////////////////////////////
        //Local Variables

        GameObject randomItem;
        GameObject spawnedItem;

        Point randomPoint;

        ////////////////////////////////

        randomPoint = getRandomSpotInRoom(room);
        randomItem = GetRandomItem();

        while (GetComponent<MapController>().IsBlocked(randomPoint) == true)
        {
            randomPoint = getRandomSpotInRoom(room);
        }

        randomPoint = DoNotSpawnOnPlayerCheck(randomPoint, room);

        spawnedItem = Instantiate(randomItem) as GameObject;
        spawnedItem.GetComponent<TileMove>().SetTransform(randomPoint.x, randomPoint.y);

        spawnedItem.name = randomItem.name;

        this.GetComponent<ItemController>().AddItem(spawnedItem);
    }

    private Point DoNotSpawnOnPlayerCheck(Point position, CustomRect room)
    {
        ////////////////////////////////////////////////////////
        //Local Variables

        GameObject player = GameObject.FindWithTag(TagKeys.PLAYER_KEY);

        Point currentPosition;
        Point playerPosition;

        ////////////////////////////////////////////////////////

        currentPosition = new Point(position);
        playerPosition = player.GetComponent<Tile>().GetPosition();

        while (playerPosition.Equals(currentPosition) == true)
        {
            currentPosition = getRandomSpotInRoom(room);
        }

        return currentPosition;
    }

    private GameObject GetRandomItem()
    {
        return Items[Random.Range(0, Items.Length)];
    }

    private bool SpawnItem()
    {
        /////////////////////////////////////
        //Local Variables

        bool result = false;

        int randomValue = 0;

        /////////////////////////////////////

        NewMaxSpawnCheck(GetComponent<ItemController>().GetItems().Length);

        if (GetComponent<ItemController>().GetItems().Length == MaxSpawns)
        {
            result = false;
            return result;
        }

        randomValue = Random.Range(0, 100);

        if (randomValue <= SpawnRate)
        {
            result = true;
        }

        return result;
    }

    #endregion
}
