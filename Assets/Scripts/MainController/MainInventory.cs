using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This will manage all the items the player has.
/// </summary>
public class MainInventory : MonoBehaviour
{
    #region Public Methods

    public void AddItem(GameObject newItem)
    {
        ModelControl.GetItemListFromModel().Add(newItem.GetComponent<ItemAI>().MainState);
    }

    public AbstractItemAI GetItem(int index)
    {
        if (IndexWithinBounds(index) == true)
        {
            return ModelControl.GetItemListFromModel()[index];
        }

        else
        {
            return null;
        }
    }

    /// <summary>
    /// NOTE:  This might have some issues.  It is returning the first record found of
    /// an item.  I'll leave it commented out.
    /// </summary>
    public void RemoveItem(GameObject item)
    {
        ModelControl.GetItemListFromModel().Remove(item.GetComponent<ItemAI>().MainState);
        //inventory.Remove(item);
    }

    public void ClearInventory()
    {
        ModelControl.GetItemListFromModel().Clear();
    }

    /// <summary>
    /// This will check if item exists in the inventory.  it will return -1 if the
    /// item isn't found, or the index of the item if it does exist.
    /// </summary>
    public int ItemIndexInInventory(GameObject item)
    {
        return ModelControl.GetItemListFromModel().IndexOf(item.GetComponent<ItemAI>().MainState);
    }

    public int GetInventoryCount()
    {
        return ModelControl.GetItemListFromModel().Count;
    }

    #endregion

    #region Private Methods

    private bool IndexWithinBounds(int index)
    {
        /////////////////////////////////////////////////
        //Local Variables

        List<AbstractItemAI> list;

        /////////////////////////////////////////////////

        list = ModelControl.GetItemListFromModel();

        if ((index > -1) && (index < list.Count))
        {
            return true;
        }

        return false;
    }

    #endregion
}
