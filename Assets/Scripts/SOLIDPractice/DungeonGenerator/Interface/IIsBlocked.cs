using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIsBlocked
{
    bool IsBlocked(int x, int y);
    bool IsBlocked(Point _position);
}
