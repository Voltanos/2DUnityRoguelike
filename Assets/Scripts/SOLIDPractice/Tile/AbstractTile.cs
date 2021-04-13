using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTile : IEqualToOtherPosition, IGetPosition
{
    #region Public Methods

    public virtual Point GetPosition()
    {
        //Override.
        return new Point();
    }

    public virtual bool EqualToOtherPosition(Tile other)
    {
        //Override.
        return false;
    }

    #endregion
}
