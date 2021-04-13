using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This will draw a GUI Button.
/// </summary>
[Serializable]
public class GUIButton
{
    #region Member Variables

    public bool Enabled = true;

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

    public bool Draw()
    {
        /////////////////////////////////////////////////////////
        //Local Variables

        bool result;

        /////////////////////////////////////////////////////////

        ChangeColor();

        GUI.enabled = this.Enabled;

        this._FinalBox = GetRectBasedOnResolution.Start(this.BaseBox);

        result = GUI.Button(this._FinalBox, this.Content);

        ResetColor();

        GUI.enabled = true;

        return result;
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

