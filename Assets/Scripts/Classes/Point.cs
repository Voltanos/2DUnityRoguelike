using UnityEngine;
using System.Collections;

public class Point
{
    #region Member Variables

    public int x;
    public int y;

    #endregion

    #region Constructors

    public Point()
    {
        x = 0;
        y = 0;
    }

    public Point(int _x, int _y)
    {
        x = _x;
        y = _y;
    }

    public Point(Point other)
    {
        this.x = other.x;
        this.y = other.y;
    }

    #endregion

    #region Public Methods

    public override bool Equals(object obj)
    {
        //////////////////////////////////////
        //Local Variables

        Point other;

        //////////////////////////////////////

        if ((obj == null) || GetType() != obj.GetType())
        {
            return false;
        }

        other = (Point)obj;

        return ((this.x == other.x) && (this.y == other.y));
    }

    public static bool operator ==(Point main, Point other)
    {
        return ((main.x == other.x) && (main.y == other.y));
    }

    public static bool operator !=(Point main, Point other)
    {
        return !((main.x == other.x) && (main.y == other.y));
    }

    public static bool operator <(Point main, Point other)
    {
        return ((main.x < other.x) && (main.y < other.y));
    }

    public static bool operator >(Point main, Point other)
    {
        return ((main.x > other.x) && (main.y > other.y));
    }

    public override int GetHashCode()
    {
        return this.x ^ this.y;
    }

    #endregion
}
