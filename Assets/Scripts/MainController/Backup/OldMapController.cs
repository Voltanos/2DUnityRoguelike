/*

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

    #endregion

    #region Properties

    public int GetDungeonLevel
    {
        get
        {
            return DungeonLevel;
        }
    }

    #endregion

    #region MonoBehaviour Events.

    // Use this for initialization
    void Start()
    {
        ResetDungeon();
    }

    #endregion

    #region Public Methods

    public void ResetDungeon()
    {
        GetComponent<ItemController>().Reset();
        GetComponent<LadderGenerator>().ResetLadder();
        GetComponent<MonsterController>().Reset();

        RemoveTiles();

        CreateTileGrid();
        BaseMap();
    }

    public bool InBounds(int x, int y)
    {
        //////////////////////////////////////////
        //Local Variables

        //Bool Variables
        bool isValid = false;

        //////////////////////////////////////////

        if
        (
            ((x >= 0) && (x < DungeonX)) &&
            ((y >= 0) && (y < DungeonY))
        )
        {
            isValid = true;
        }

        return isValid;
    }

    public GameObject GetTile(int x, int y)
    {
        ///////////////////////////////////
        //Local Variables

        bool isValid = false;

        ///////////////////////////////////

        if ((x >= 0) && (x < DungeonX))
        {
            if ((y >= 0) && (y < DungeonY))
            {
                isValid = true;
                return Tiles[x, y];
            }
        }

        if (isValid == false)
        {
            StaticTrace.Log(string.Format("Error!  Either {0} or {1} is out of bounds!  Returning null.", x, y));
        }

        return null;
    }

    public bool IsBlocked(int x, int y)
    {
        ///////////////////////////////////////
        //Local Variables

        GameObject tile;

        GameObject monster;

        ///////////////////////////////////////

        tile = GetTile(x, y);

        if (tile.GetComponent<Tile>().Blocked == true)
        {
            return true;
        }

        monster = this.GetComponent<MonsterController>().GetMonsterAtTile(x, y);

        if (monster != null)
        {
            return true;
        }

        return false;
    }

    public bool IsBlocked(Point _position)
    {
        return IsBlocked(_position.x, _position.y);
    }

    #endregion

    #region Private Methods

    private void RemoveTiles()
    {
        ///////////////////////////////////////////////////////////////
        //Local Variables

        int x = 0;
        int y = 0;

        ///////////////////////////////////////////////////////////////

        for (x = 0; x < DungeonX; x += 1)
        {
            for (y = 0; y < DungeonY; y += 1)
            {
                if (Tiles != null)
                {
                    if (Tiles[x, y] != null)
                    {
                        GameObject.Destroy(Tiles[x, y]);
                    }
                }
            }
        }

        Tiles = new GameObject[0, 0];
    }

    private void CreateHTunnel(int x1, int x2, int y)
    {
        //////////////////////////////////////////////////
        //Local Variables

        int min = 0;
        int max = 0;

        //////////////////////////////////////////////////

        min = Mathf.Min(x1, x2);
        max = Mathf.Max(x1, x2) + 1;

        for (int x = min; x < max; x += 1)
        {
            Tiles[x, y].GetComponent<Tile>().Blocked = false;
            Tiles[x, y].GetComponent<Tile>().BlockSight = false;
            Tiles[x, y].GetComponent<TileSpriteController>().ResetSpriteController();
        }
    }

    private void CreateVTunnel(int y1, int y2, int x)
    {
        //////////////////////////////////////////////////
        //Local Variables

        int min = 0;
        int max = 0;

        //////////////////////////////////////////////////

        min = Mathf.Min(y1, y2);
        max = Mathf.Max(y1, y2) + 1;

        for (int y = min; y < max; y += 1)
        {
            Tiles[x, y].GetComponent<Tile>().Blocked = false;
            Tiles[x, y].GetComponent<Tile>().BlockSight = false;
            Tiles[x, y].GetComponent<TileSpriteController>().ResetSpriteController();
        }
    }

    private void CreateRoom(CustomRect room)
    {
        for (int x = room.x1 + 1; x < room.x2; x += 1)
        {
            for (int y = room.y1 + 1; y < room.y2; y += 1)
            {
                Tiles[x, y].GetComponent<Tile>().Blocked = false;
                Tiles[x, y].GetComponent<Tile>().BlockSight = false;
                Tiles[x, y].GetComponent<TileSpriteController>().ResetSpriteController();
            }
        }

        GetComponent<MonsterGenerator>().MonsterSpawnCheck(room);
        GetComponent<ItemGenerator>().ItemSpawnCheck(room);
        GetComponent<LadderGenerator>().LadderSpawnCheck(room, MaxRooms);
    }

    private void CreateTileGrid()
    {
        ///////////////////////////////////////////
        //Local Variables

        int x = 0;
        int y = 0;

        ///////////////////////////////////////////

        Tiles = new GameObject[DungeonX, DungeonY];

        for (x = 0; x < DungeonX; x += 1)
        {
            for (y = 0; y < DungeonY; y += 1)
            {
                Tiles[x, y] = Instantiate(Tile) as GameObject;
                Tiles[x, y].name = string.Format("Tile_{0}_{1}_{2}", DungeonLevel, x.ToString(), y.ToString());
                Tiles[x, y].GetComponent<TileMove>().SetTransform(x, y);
            }
        }
    }

    private void BaseMap()
    {
        ///////////////////////////////////////////
        //Local Variables

        CustomRect[] rooms = new CustomRect[MaxRooms];

        int numRooms = 0;

        CustomRect newRoom;

        bool failed;

        ///////////////////////////////////////////

        for (int x = 0; x < MaxRooms; x += 1)
        {
            newRoom = CreateRandomRoom();
            failed = CheckForIntersect(newRoom, rooms);
            rooms = AddRoom(newRoom, failed, ref numRooms, rooms);
        }

        DungeonLevel += 1;
    }

    private CustomRect CreateRandomRoom()
    {
        ////////////////////////////////////////
        //Local Variables

        int width = 0;
        int height = 0;
        int xStart = 0;
        int yStart = 0;

        CustomRect newRoom;

        ////////////////////////////////////////

        width = Random.Range(MinRoomSize, MaxRoomSize);
        height = Random.Range(MinRoomSize, MaxRoomSize);

        xStart = Random.Range(0, DungeonX - width - 1);
        yStart = Random.Range(0, DungeonY - height - 1);

        newRoom = new CustomRect(xStart, yStart, width, height);

        return newRoom;
    }

    private bool CheckForIntersect(CustomRect newRoom, CustomRect[] rooms)
    {
        ///////////////////////////////////////
        //Local Variables

        bool failed = false;

        ///////////////////////////////////////

        foreach (CustomRect room in rooms)
        {
            if (room == null)
            {
                continue;
            }

            if (newRoom.intersect(room) == true)
            {
                failed = true;
            }
        }

        return failed;
    }

    private CustomRect[] AddRoom(CustomRect newRoom, bool failed, ref int numRooms, CustomRect[] rooms)
    {
        //////////////////////////////////////
        //Local Variables

        Point newRoomCenter;
        Point prevRoomCenter;

        //////////////////////////////////////

        if (failed == true)
        {
            return rooms;
        }

        CreateRoom(newRoom);

        newRoomCenter = newRoom.GetCenter();

        if (numRooms == 0)
        {
            SetPlayerPosition(newRoomCenter);
        }

        else
        {
            prevRoomCenter = rooms[numRooms - 1].GetCenter();
            ConnectRooms(newRoomCenter, prevRoomCenter);
        }

        rooms[numRooms] = newRoom;
        numRooms += 1;

        return rooms;
    }

    private void ConnectRooms(Point newCenter, Point prevCenter)
    {
        /////////////////////////////////////////
        //Local Variables

        int coinToss = 0;

        /////////////////////////////////////////

        coinToss = Random.Range(0, 1);

        if (coinToss == 1)
        {
            CreateHTunnel(prevCenter.x, newCenter.x, prevCenter.y);
            CreateVTunnel(prevCenter.y, newCenter.y, newCenter.x);
        }

        else
        {
            CreateVTunnel(prevCenter.y, newCenter.y, prevCenter.x);
            CreateHTunnel(prevCenter.x, newCenter.x, newCenter.y);
        }
    }

    private void SetPlayerPosition(Point newRoomCenter)
    {
        ////////////////////////////////////////////
        //Local Variables

        GameObject player;

        ////////////////////////////////////////////

        player = GameObject.FindWithTag(TagKeys.PLAYER_KEY);

        player.GetComponent<TileMove>().SetTransform(newRoomCenter.x, newRoomCenter.y);
    }

    #endregion
}

*/