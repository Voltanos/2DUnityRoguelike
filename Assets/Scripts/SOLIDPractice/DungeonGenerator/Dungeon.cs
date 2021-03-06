using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : IMap, IGetTile, IInBounds, IIsBlocked, IGetDungeonLevel
{
    private int DungeonX;
    private int DungeonY;
    private int MaxRoomSize;
    private int MinRoomSize;
    private int MaxRooms;
    private int DungeonLevel;

    private GameObject Tile;

    private GameObject[,] Tiles;

    private ItemController ItemController;

    private LadderGenerator LadderGenerator;

    private MonsterController MonsterController;

    private ItemGenerator ItemGenerator;

    private MonsterGenerator MonsterGenerator;

    private Logger Logger;

    #region Constructor

    public Dungeon
        (
            Logger logger,
            ItemController itemController,
            LadderGenerator ladderGenerator,
            MonsterController monsterController,
            ItemGenerator itemGenerator,
            MonsterGenerator monsterGenerator,
            GameObject tile,
            int dungeonX,
            int dungeonY,
            int maxRoomSize,
            int minRoomSize,
            int maxRooms,
            int dungeonLevel
        )
    {
        this.Logger = logger;
        this.ItemController = itemController;
        this.LadderGenerator = ladderGenerator;
        this.MonsterController = monsterController;
        this.ItemGenerator = itemGenerator;
        this.MonsterGenerator = monsterGenerator;

        this.Tile = tile;

        this.DungeonX = dungeonX;
        this.DungeonY = dungeonY;
        this.MaxRoomSize = maxRoomSize;
        this.MinRoomSize = minRoomSize;
        this.MaxRooms = maxRooms;
        this.DungeonLevel = dungeonLevel;
    }

    #endregion

    #region Public Methods

    public void ResetDungeon()
    {
        this.ItemController.Reset();
        this.LadderGenerator.ResetLadder();
        this.MonsterController.Reset();

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
            this.Logger.Log(string.Format("Error!  Either {0} or {1} is out of bounds!  Returning null.", x, y));
        }

        return null;
    }

    public GameObject GetTile(Point position)
    {
        return GetTile(position.x, position.y);
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

        monster = this.MonsterController.GetMonsterAtTile(x, y);

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

    public int GetDungeonLevel()
    {
        return DungeonLevel;
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

        this.MonsterGenerator.MonsterSpawnCheck(room);
        this.ItemGenerator.ItemSpawnCheck(room);
        this.LadderGenerator.LadderSpawnCheck(room, MaxRooms);
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
                Tiles[x, y] = GameObject.Instantiate(Tile) as GameObject;
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
