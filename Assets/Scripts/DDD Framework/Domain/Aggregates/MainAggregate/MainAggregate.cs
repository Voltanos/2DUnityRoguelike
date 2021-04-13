using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This is the main aggregate that should hold all player settings and
/// permament items used in the game.
/// </summary>
[System.Serializable]
public class MainAggregate
{
    #region Member Variables

    public FighterAttributes PlayerAttributes { get; set; }

    public List<AbstractItemAI> InventoryAIList { get; set; }

    public InputSettings InputSettings { get; set; }

    #endregion

    #region Constructors

    public MainAggregate()
    {
        this.PlayerAttributes = new FighterAttributes();

        this.InventoryAIList = new List<AbstractItemAI>();

        this.InputSettings = new InputSettings();
    }

    #endregion
}
