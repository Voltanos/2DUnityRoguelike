using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This will display the available actions for this item.
/// </summary>
public class ItemActionMenu : MonoBehaviour
{
    #region Member Variables

    private GameObject Player = null;
    private GameObject GameController = null;

    public GUIBox GUIBox;

    public GUIButton OnUseButton;
    public GUIButton OnEquipButton;
    public GUIButton OnUnequipButton;
    public GUIButton OnDropButton;
    public GUIButton OnExamineButton;

    public bool DrawGUI;

    private int ItemIndex = -1;

    #endregion

    #region MonoBehaviour Methods

    void Start()
    {
        GetGameObjects();
    }

    void OnGUI()
    {
        try
        {
            DrawActionMenuGUI();
        }

        catch (Exception ex)
        {
            StaticTrace.ExceptionLog(ex.Message, ex.StackTrace);
        }
    }

    #endregion

    #region Member Methods

    private void GetGameObjects()
    {
        if (GameController == null)
        {
            GameController = GameObject.FindWithTag(TagKeys.MAIN_CONTROLLER_KEY);
        }

        if (Player == null)
        {
            Player = GameObject.FindWithTag(TagKeys.PLAYER_KEY);
        }
    }

    private void DrawActionMenuGUICheck()
    {
        GetGameObjects();

        if (DrawGUI == true)
        {
            DrawActionMenuGUI();
        }
    }

    private void DrawActionMenuGUI()
    {
        ////////////////////////////////////////
        //Local Variables

        //AbstractItemAI item = null;

        GameObject item = new GameObject();

        ItemAI ai;

        ////////////////////////////////////////

        ai = item.AddComponent<ItemAI>();

        ai.MainState = GameController.GetComponent<MainInventory>().GetItem(ItemIndex);        

        if (ai.MainState == null)
        {
            Destroy(item);
            return;
        }

        item.name = ai.MainState.ItemName;

        GUIBox.Draw();

        OnUseButton.Enabled = ai.MainState.OnUseCheck;
        OnEquipButton.Enabled = ai.MainState.OnEquipCheck;
        OnUnequipButton.Enabled = ai.MainState.OnUnequipCheck;
        OnDropButton.Enabled = ai.MainState.OnDropCheck;

        if (OnUseButton.Draw() == true)
        {
            item.GetComponent<ItemAI>().OnUse(Player);
            Player.GetComponent<PlayerActions>().ActionPerformed();
            DrawGUI = false;
        }        

        if (OnEquipButton.Draw() == true)
        {
            item.GetComponent<ItemAI>().OnEquip(Player);
            Player.GetComponent<PlayerActions>().ActionPerformed();
            DrawGUI = false;
        }

        if (OnUnequipButton.Draw() == true)
        {
            item.GetComponent<ItemAI>().OnUnequip(Player);
            Player.GetComponent<PlayerActions>().ActionPerformed();
            DrawGUI = false;
        }

        if (OnDropButton.Draw() == true)
        {
            item.GetComponent<ItemAI>().OnDrop(Player);
            Player.GetComponent<PlayerActions>().ActionPerformed();
            DrawGUI = false;
        }

        if (OnExamineButton.Draw() == true)
        {
            item.GetComponent<ItemAI>().OnExamine();
            DrawGUI = false;
        }

        Destroy(item);
    }

    public void SetItemIndex(int index)
    {
        ItemIndex = index;
        DrawGUI = true;
    }

    public void ResetItemIndex()
    {
        ItemIndex = -1;
        DrawGUI = false;
    }

    #endregion
}
