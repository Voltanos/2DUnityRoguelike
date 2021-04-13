using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This will manage all the positions of items.
/// </summary>
public class ItemController : MonoBehaviour
{
    #region Member Variables

    private Dictionary<Vector3, GameObject> ItemDictionary;

    #endregion

    #region MonoBehaviour Events

    // Use this for initialization
    void Awake()
    {
        ItemDictionary = new Dictionary<Vector3, GameObject>();
    }

    #endregion

    #region Member Methods

    public void Reset()
    {
        foreach (GameObject item in ItemDictionary.Values)
        {
            DestroyItemsNotInInventory(item);
        }

        ItemDictionary.Clear();
    }    

    public void AddItem(GameObject newItem)
    {
        ItemDictionary.Add(newItem.transform.position, newItem);
    }

    public void RemoveItem(GameObject removeItem)
    {
        ItemDictionary.Remove(removeItem.transform.position);
    }

    public GameObject[] GetItems()
    {
        /////////////////////////////////////////////////
        //Local Variables

        List<GameObject> array;

        /////////////////////////////////////////////////

        array = new List<GameObject>(ItemDictionary.Values);

        return array.ToArray();
    }

    public GameObject GetItemAtTile(int x, int y)
    {
        ////////////////////////////////////////////////////
        //Local Variables

        Vector3 position;

        ////////////////////////////////////////////////////

        position = new Vector3(x, y, 0);

        if (ItemDictionary.ContainsKey(position) == true)
        {
            return ItemDictionary[position];
        }

        else
        {
            return null;
        }
    }

    public GameObject GetItemAtTile(Vector3 vector)
    {
        if (ItemDictionary.ContainsKey(vector) == true)
        {
            return ItemDictionary[vector];
        }

        else
        {
            return null;
        }
    }

    #endregion

    #region Private Methods

    private void DestroyItemsNotInInventory(GameObject item)
    {
        ///////////////////////////////////////////////////
        //Local Variables

        int index = 0;

        ///////////////////////////////////////////////////

        index = GetComponent<MainInventory>().ItemIndexInInventory(item);

        if (index == -1)
        {
            GameObject.Destroy(item);
        }
    }

    #endregion
}
