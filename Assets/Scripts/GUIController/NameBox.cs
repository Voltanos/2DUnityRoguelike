using UnityEngine;
using System.Collections;

/// <summary>
/// This will show off the name of a tile.
/// </summary>
[System.Serializable]
public class NameBox : MonoBehaviour
{
    #region Member Variables

    public GUIBox guiBox;

    public GUILabel nameLabel;

    public bool ShowName;
    public bool DebugMessage = false;

    #endregion

    #region Monobehavior Methods

    // Update is called once per frame
    void OnGUI()
    {
        DisplayNameBox();
    }

    #endregion

    #region Member Methods

    private void DisplayNameBox()
    {
        if (ShowName == true)
        {
            guiBox.Draw();
            nameLabel.Draw();
        }
    }

    public void SetNameBox(string name)
    {
        if (DebugMessage == true)
        {
            StaticTrace.Log(string.Format("New NameBox:  {0}", name));
        }        

        nameLabel.Content.text = name;

        ShowName = true;
    }

    public void ClearNameBox()
    {
        nameLabel.Content.text = "";

        ShowName = false;
    }

    #endregion
}
