using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MapController : MonoBehaviour
{
    #region Member Variables

    public int DungeonX;
    public int DungeonY;
    public int MaxRoomSize;
    public int MinRoomSize;
    public int MaxRooms;

    public GameObject Tile;

    private GameObject[,] Tiles;

    private int DungeonLevel = 0;

    private Dungeon ClassicDungeon;

    #endregion

    #region Properties

    public int GetDungeonLevel
    {
        get
        {
            return ClassicDungeon.GetDungeonLevel();
        }
    }

    #endregion

    #region MonoBehaviour Events.

    // Use this for initialization
    void Start()
    {
        ClassicDungeon = new Dungeon(
            new Logger(),
            GetComponent<ItemController>(),
            GetComponent<LadderGenerator>(),
            GetComponent<MonsterController>(),
            GetComponent<ItemGenerator>(),
            GetComponent<MonsterGenerator>(),
            Tile,
            DungeonX,
            DungeonY,
            MaxRoomSize,
            MinRoomSize,
            MaxRooms,
            DungeonLevel);
        ClassicDungeon.ResetDungeon();
    }

    #endregion

    #region Public Methods

    public void ResetDungeon()
    {
        ClassicDungeon.ResetDungeon();
    }

    public bool InBounds(int x, int y)
    {
        return ClassicDungeon.InBounds(x, y);
    }

    public GameObject GetTile(int x, int y)
    {
        return ClassicDungeon.GetTile(x, y);
    }

    public bool IsBlocked(int x, int y)
    {
        return ClassicDungeon.IsBlocked(x, y);
    }

    public bool IsBlocked(Point _position)
    {
        return ClassicDungeon.IsBlocked(_position);
    }

    #endregion
}
