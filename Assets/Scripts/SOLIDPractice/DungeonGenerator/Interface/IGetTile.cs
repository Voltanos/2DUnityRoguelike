using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGetTile
{
    GameObject GetTile(int x, int y);
    GameObject GetTile(Point position);
}
