using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This will display the current number of items the player has collected.
/// </summary>
public class InventoryGUI : MonoBehaviour
{
    #region Member Variables

    public GUIBox GUIBox;

    public GUIButton[] ItemButtons;

    public GUIButton PrevButton;
    public GUIButton NextButton;

    private GameObject MainController = null;

    private GUIController GUIController;

    private int[] ItemIndex;

    private int PageIndex = 1;

    #endregion

    #region MonoBehaviour Methods

    void Start()
    {
        try
        {
            GetMainController();
        }

        catch (Exception ex)
        {
            StaticTrace.ExceptionLog(ex.Message, ex.StackTrace);
        }
    }

    void OnGUI()
    {
        try
        {
            CanDrawGUI();
        }

        catch (Exception ex)
        {
            StaticTrace.ExceptionLog(ex.Message, ex.StackTrace);
        }
    }

    #endregion

    #region Member Methods

    private void GetMainController()
    {
        if (MainController == null)
        {
            MainController = GameObject.FindWithTag(TagKeys.MAIN_CONTROLLER_KEY);
        }

        if (GUIController == null)
        {
            GUIController = GetComponent<GUIController>();
        }
    }

    private void CanDrawGUI()
    {
        /////////////////////////////////////////
        //Local Variables

        bool drawGUI = false;

        /////////////////////////////////////////

        GetMainController();

        drawGUI = GUIController.GetDrawInventoryGUI;

        if (drawGUI == false)
        {
            ResetActionMenu();
        }

        else
        {
            DrawInventoryGUI();
        }
    }

    private void DrawInventoryGUI()
    {
        ////////////////////////////////////////
        //Local Variables

        int allButtonIndex = 0;

        ////////////////////////////////////////

        GUIBox.Draw();

        ResetButtons();

        for (allButtonIndex = 0; allButtonIndex < ItemButtons.Length; allButtonIndex += 1)
        {
            DrawItemButtons(allButtonIndex);
        }

        if (PrevButton.Draw() == true)
        {
            PreviousPage();
        }

        if (NextButton.Draw() == true)
        {
            NextPage();
        }
    }

    private void DrawItemButtons(int allButtonIndex)
    {
        ////////////////////////////////////////
        //Local Variables

        int itemIndex = 0;

        AbstractItemAI item = null;

        ////////////////////////////////////////

        /*
        NOTE:  GetStartPageIndex() will return a new spot somewhere within the list of items to start based on pageIndex.  For example, if pageIndex was 1
        and itemButtons.Length was 6, then it will start at 0 and will retrieve 0 + allButtonIndex from all the items.  However if pageIndex was 2, then it
        will return 6 + allButtonIndex from all the items.
        */
        itemIndex = GetStartPageIndex() + allButtonIndex;
        item = MainController.GetComponent<MainInventory>().GetItem(itemIndex);

        if (item == null)
        {
            return;
        }

        ItemButtons[allButtonIndex].Content.text = item.ItemName;

        if (ItemButtons[allButtonIndex].Draw() == true)
        {
            gameObject.GetComponent<ItemActionMenu>().SetItemIndex(itemIndex);
        }
    }

    private void PreviousPage()
    {
        PageIndex -= 1;

        if (PageIndex < 1)
        {
            PageIndex = 1;
        }
    }

    private void NextPage()
    {
        /////////////////////////////////////////
        //Local Variables

        int length = 0;
        int startPage = 0;

        /////////////////////////////////////////

        PageIndex += 1;

        length = MainController.GetComponent<MainInventory>().GetInventoryCount();
        startPage = GetStartPageIndex();

        while (startPage > length)
        {
            PageIndex -= 1;
            startPage = GetStartPageIndex();
        }
    }

    private int GetStartPageIndex()
    {
        return (ItemButtons.Length * PageIndex) - ItemButtons.Length;
    }

    private void ResetButtons()
    {
        /////////////////////////////////////////////////
        //Local Variables

        int i = 0;

        /////////////////////////////////////////////////

        ItemIndex = new int[ItemButtons.Length];

        for (i = 0; i < ItemIndex.Length; i += 1)
        {
            ItemIndex[i] = -1;

            ItemButtons[i].Content.text = "";
        }
    }

    private void ResetActionMenu()
    {
        GetComponent<ItemActionMenu>().ResetItemIndex();
    }

    #endregion
}
