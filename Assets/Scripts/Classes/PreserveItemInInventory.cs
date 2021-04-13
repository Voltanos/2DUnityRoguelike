using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This will help with preserving items when added to the player's inventory.
/// </summary>
public class PreserveItemInInventory : MonoBehaviour
{
    #region Public Methods

    public void PreserveItem()
    {
        try
        {
            TryPreserve();
        }

        catch (Exception ex)
        {
            StaticTrace.Log(ex.Message);
            StaticTrace.Log(ex.StackTrace);
        }
    }

    #endregion

    #region Private Methods

    private void TryPreserve()
    {
        UnityEngine.Object.DontDestroyOnLoad(gameObject);
    }

    #endregion
}
