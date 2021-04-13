using UnityEngine;
using System.Collections;

[System.Serializable]
public class MonsterGenerator : MonoBehaviour
{
    #region Member Variables

    public GameObject[] Monsters;

    public int MaxNumOfMonsters = 5;

    public int SpawnRate = 50;

    private int MaxSpawns;

    #endregion

    #region Public Methods

    public void MonsterSpawnCheck(CustomRect _room)
    {
        if (SpawnMonster() == true)
        {
            CreateMonster(_room);
        }
    }

    public void NewMaxSpawnCheck(int length)
    {
        if (length == 0)
        {
            MaxSpawns = MaxSpawnGenerator.Start(MaxNumOfMonsters);
        }
    }

    #endregion

    #region Private Methods

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

    private void CreateMonster(CustomRect _room)
    {
        ////////////////////////////////
        //Local Variables

        GameObject randomMonster;
        GameObject spawnedMonster;

        Point randomPoint;

        ////////////////////////////////

        randomPoint = GetRandomSpotInRoom(_room);
        randomMonster = GetRandomMonster();

        while (GetComponent<MapController>().IsBlocked(randomPoint) == true)
        {
            randomPoint = GetRandomSpotInRoom(_room);
        }

        spawnedMonster = Instantiate(randomMonster) as GameObject;
        spawnedMonster.GetComponent<TileMove>().SetTransform(randomPoint.x, randomPoint.y);

        spawnedMonster.name = randomMonster.name;

        this.GetComponent<MonsterController>().AddMonster(spawnedMonster);
    }

    private GameObject GetRandomMonster()
    {
        return Monsters[Random.Range(0, Monsters.Length)];
    }

    private bool SpawnMonster()
    {
        /////////////////////////////////////
        //Local Variables

        bool result = false;

        int randomValue = 0;

        /////////////////////////////////////

        NewMaxSpawnCheck(GetComponent<MonsterController>().GetMonsters().Length);

        if (GetComponent<MonsterController>().GetMonsters().Length == MaxSpawns)
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
