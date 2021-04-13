using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This component will initialize an abstract item-AI class to the gameObject.
/// </summary>
public class CreateConfusionScroll : MonoBehaviour
{
    #region Monobehavior Events

    void Awake()
    {
        ////////////////////////////////////////////////////////
        //Local Variables

        AbstractItemAI newState = new ConfusionScrollAI();

        ////////////////////////////////////////////////////////

        newState.ItemName = RemoveCloneFromName.Start(gameObject.name);
        newState.TimeStamp = DateTime.Now;

        gameObject.GetComponent<ItemAI>().ChangeState(newState);
    }

    #endregion
}

