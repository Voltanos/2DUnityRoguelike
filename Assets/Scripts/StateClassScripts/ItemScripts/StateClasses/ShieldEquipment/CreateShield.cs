using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This component will initialize the abstract Shield-AI class to the gameObject.
/// </summary>
public class CreateShield : MonoBehaviour
{
    #region Monobehavior Events	

    //For Initialization.
    void Awake()
    {
        ////////////////////////////////////////////////////////
        //Local Variables

        AbstractItemAI newState = new ShieldAI();

        ////////////////////////////////////////////////////////

        newState.ItemName = RemoveCloneFromName.Start(gameObject.name);
        newState.TimeStamp = DateTime.Now;

        gameObject.GetComponent<ItemAI>().ChangeState(newState);
    }

    #endregion
}
