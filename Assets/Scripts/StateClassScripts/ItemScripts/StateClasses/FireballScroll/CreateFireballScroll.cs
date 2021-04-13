using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This component will initialize a FireBall item to the gameObject.
/// </summary>
public class CreateFireballScroll : MonoBehaviour
{
    #region Monobehavior Events

    void Awake()
    {
        ////////////////////////////////////////////////////////
        //Local Variables

        AbstractItemAI newState = new FireballScrollAI();

        ////////////////////////////////////////////////////////

        newState.ItemName = RemoveCloneFromName.Start(gameObject.name);
        newState.TimeStamp = DateTime.Now;

        gameObject.GetComponent<ItemAI>().ChangeState(newState);
    }

    #endregion
}

