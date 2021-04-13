using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This should hold all the input commands for the game.
/// </summary>
[System.Serializable]
public class InputSettings
{
    #region Member Variables

    public KeyCode MoveUp;
    public KeyCode MoveDown;
    public KeyCode MoveLeft;
    public KeyCode MoveRight;
    public KeyCode OpenInventory;
    public KeyCode MainMenu;
    public KeyCode GoDownLadder;
    public KeyCode OpenCharacterSheet;
    public KeyCode MessageWindowScrollUp;
    public KeyCode MessageWindowScrollDown;    

    #endregion

    public InputSettings()
    {
        this.MoveUp = KeyCode.UpArrow;
        this.MoveDown = KeyCode.DownArrow;
        this.MoveLeft = KeyCode.LeftArrow;
        this.MoveRight = KeyCode.RightArrow;
        this.OpenInventory = KeyCode.I;
        this.MainMenu = KeyCode.Escape;
        this.GoDownLadder = KeyCode.Greater;
        this.OpenCharacterSheet = KeyCode.C;
        this.MessageWindowScrollUp = KeyCode.PageUp;
        this.MessageWindowScrollDown = KeyCode.PageDown;
    }
}
