using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This component will initialize an abstract item-AI class to the gameObject.
/// </summary>
public class CreateLightningBoltScroll : MonoBehaviour
{
    #region Monobehavior Events

    //For Initialization.
    void Awake()
    {
        ////////////////////////////////////////////////////////
        //Local Variables

        AbstractItemAI newState = new LightningBoltScrollAI();

        ////////////////////////////////////////////////////////

        newState.ItemName = RemoveCloneFromName.Start(gameObject.name);
        newState.TimeStamp = DateTime.Now;

        gameObject.GetComponent<ItemAI>().ChangeState(newState);
    }

    #endregion
}
