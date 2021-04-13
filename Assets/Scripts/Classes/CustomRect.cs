using UnityEngine;
using System.Collections;

public class CustomRect
{
    #region Member Variables

    public int x1;
    public int y1;
    public int x2;
    public int y2;

    #endregion

    #region Constructors

    public CustomRect()
    {
        x1 = 5;
        y1 = 5;
        x2 = x1 + 5;
        y2 = y1 + 5;
    }

    public CustomRect(int _x, int _y, int _width, int _height)
    {
        x1 = _x;
        y1 = _y;
        x2 = x1 + _width;
        y2 = y1 + _height;
    }

    #endregion

    #region Member Methods

    public Point GetCenter()
    {
        //////////////////////////////////////
        //Local Variables

        Point center = new Point();

        //////////////////////////////////////

        center.x = (x1 + x2) / 2;
        center.y = (y1 + y2) / 2;

        return center;
    }

    public bool intersect(CustomRect other)
    {
        if
        (
            (x1 <= other.x2) &&
            (x2 >= other.x1) &&
            (y1 <= other.y2) &&
            (y2 >= other.y1)
        )
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    #endregion
}
