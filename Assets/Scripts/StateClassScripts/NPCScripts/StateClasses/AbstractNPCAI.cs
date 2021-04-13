using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Abstract class for State-Class Design Pattern for NPCs.
/// </summary>
[System.Serializable]
public abstract class AbstractNPCAI
{
    #region Member Methods

    abstract public void Enter(GameObject main);
    abstract public void Execute(GameObject main);
    abstract public void Exit(GameObject main);

    #endregion
}
