using UnityEngine;
using System.Collections;

/// <summary>
/// This will display the name of the entity when the mouse hovers over it.
/// </summary>
public class NameMouseOver : MonoBehaviour
{
    #region MonoBehavior events

    public void OnMouseEnter()
    {
        DisplayName();
    }

    public void OnMouseExit()
    {
        HideName();
    }

    #endregion

    #region Private Methods

    private GameObject GetGUIController()
    {
        return GameObject.FindWithTag(TagKeys.GUI_CONTROLLER_KEY);
    }

    private void DisplayName()
    {
        /////////////////////////////////
        //Local Variables

        GameObject guiController;

        NameBox nameBox;

        /////////////////////////////////

        guiController = GetGUIController();
        nameBox = guiController.GetComponent<NameBox>();
        nameBox.SetNameBox(gameObject.name);
    }

    private void HideName()
    {
        /////////////////////////////////
        //Local Variables

        GameObject guiController;

        NameBox nameBox;

        /////////////////////////////////

        guiController = GetGUIController();
        nameBox = guiController.GetComponent<NameBox>();
        nameBox.ClearNameBox();
    }

    #endregion
}
