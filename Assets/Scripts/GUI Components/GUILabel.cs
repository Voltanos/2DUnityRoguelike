using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class GUILabel
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

        GUI.Label(this.FinalBox, this.Content);

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

