using UnityEngine;
using System.Collections;

/// <summary>
/// This will define what kind of tile this is.
/// </summary>
public class Tile : MonoBehaviour
{
    #region Member Variables

    public TileType Type;

    public string TileName;

    public bool Blocked = true;
    public bool BlockSight = true;

    public int StepCost;
    public int HeuristicCost;
    public int TotalCost;

    #endregion

    #region MonoBehavaiour Events.

    // Use this for initialization
    void Awake()
    {
        InitializeSight();
    }

    #endregion

    #region Public Methods

    public void NullTile()
    {
        this.Type = TileType.TILE_WALL;

        this.TileName = string.Empty;

        this.Blocked = true;
        this.BlockSight = true;

        this.StepCost = -1;
        this.HeuristicCost = -1;
        this.TotalCost = -1;
    }

    public Point GetPosition()
    {
        ///////////////////////////////////////////////////
        //Local Variables

        Point position = new Point();

        ///////////////////////////////////////////////////

        position.x = (int)transform.position.x;
        position.y = (int)transform.position.y;

        return position;
    }

    public bool EqualPosition(Tile other)
    {
        ////////////////////////////////////////////////////
        //Local Variables

        Point mainPosition = new Point();
        Point otherPosition = new Point();

        ////////////////////////////////////////////////////

        mainPosition = GetPosition();
        otherPosition = other.GetPosition();

        return mainPosition == otherPosition;
    }

    public int GetX()
    {
        ////////////////////////////////////////////////////
        //Local Variables

        Point mainPosition = new Point();

        ////////////////////////////////////////////////////

        mainPosition = GetPosition();

        return mainPosition.x;
    }

    public int GetY()
    {
        ////////////////////////////////////////////////////
        //Local Variables

        Point mainPosition = new Point();

        ////////////////////////////////////////////////////

        mainPosition = GetPosition();

        return mainPosition.y;
    }

    #endregion

    #region Private Methods

    private void InitializeSight()
    {
        if (Blocked == true)
        {
            BlockSight = true;
        }
    }

    #endregion
}