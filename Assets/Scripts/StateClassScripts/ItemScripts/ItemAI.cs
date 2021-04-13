using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the ItemAI component attached to an item object.  It is used to
/// house the AbstractItem AI.
/// </summary>
public class ItemAI : MonoBehaviour
{
    #region Member Variables

    public AbstractItemAI MainState;

    #endregion

    #region MonoBehaviour Events
    
    void Awake()
    {
        MainState = new BlankItemAI();
    }

    #endregion

    #region Member Methods

    public void OnUse(GameObject itemTarget)
    {
        MainState.OnUse(gameObject, itemTarget);
    }

    public void OnEquip(GameObject itemTarget)
    {
        MainState.OnEquip(gameObject, itemTarget);
    }

    public void OnUnequip(GameObject itemTarget)
    {
        MainState.OnUnequip(gameObject, itemTarget);
    }

    public void OnDrop(GameObject itemTarget)
    {
        MainState.OnDrop(gameObject, itemTarget);
    }

    public void OnTarget(GameObject itemTarget)
    {
        MainState.OnTarget(gameObject, itemTarget);
    }

    public void OnExamine()
    {
        MainState.OnExamine(gameObject);
    }

    public void ChangeState(AbstractItemAI newState)
    {
        if (newState == null)
        {
            return;
        }

        if (MainState != null)
        {
            MainState.Exit(gameObject);
        }        

        newState.Enter(gameObject);
        MainState = newState;
    }

    #endregion
}
