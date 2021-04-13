using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This will draw a GUI Box.
/// </summary>
[Serializable]
public class GUIBox
{
    #region Member Variables

    public GUIContent Content = new GUIContent();

    public Color GUIColor = Color.white;

    public Rect BaseBox = new Rect();

    private Color DefaultColor;

    private Rect _FinalBox = new Rect();

    #endregion

    #region Properties

    public Rect FinalBox
    {
        get
        {
            return this._FinalBox;
        }
    }

    #endregion

    #region Member Functions

    public void Draw()
    {
        ChangeColor();

        this._FinalBox = GetRectBasedOnResolution.Start(this.BaseBox);

        GUI.Box(this._FinalBox, this.Content);

        ResetColor();
    }

    private void ChangeColor()
    {
        this.DefaultColor = GUI.color;
        GUI.color = this.GUIColor;
    }

    private void ResetColor()
    {
        GUI.color = this.DefaultColor;
    }

    #endregion
}

