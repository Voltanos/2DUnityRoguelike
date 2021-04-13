using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This component will initialize the abstract Sword-AI class to the gameObject.
/// </summary>
public class CreateSword : MonoBehaviour
{
    #region Monobehavior Events	

    //For Initialization.
    void Awake()
    {
        ////////////////////////////////////////////////////////
        //Local Variables

        AbstractItemAI newState = new SwordAI();

        ////////////////////////////////////////////////////////

        newState.ItemName = RemoveCloneFromName.Start(gameObject.name);
        newState.TimeStamp = DateTime.Now;

        gameObject.GetComponent<ItemAI>().ChangeState(newState);
    }

    #endregion
}
