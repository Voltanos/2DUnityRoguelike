using UnityEngine;
using System;
using System.Collections;

public class MonsterAI : MonoBehaviour
{
    #region Member Variables

    private int _BaseActions = 0;

    public int ViewRange = 5;
    public int AttackRange = 2;
    public int MaxActions = 1;

    public AbstractNPCAI MainState;

    #endregion

    #region Properties

    public int BaseActions
    {
        get
        {
            return _BaseActions;
        }

        set
        {
            _BaseActions = value;
        }
    }

    #endregion

    #region MonoBehaviour Events

    //For Initializeation.
    void Awake()
    {
        MainState = new IdleAI();
    }

    #endregion

    #region Member Methods

    public void PerformAction()
    {
        BaseActions = MaxActions;

        while (BaseActions > 0)
        {
            MainState.Execute(gameObject);

            BaseActions -= 1;
        }
    }

    public void ChangeState(AbstractNPCAI newState)
    {
        if ((newState == null) || (MainState == null))
        {
            return;
        }

        MainState.Exit(gameObject);

        newState.Enter(gameObject);
        MainState = newState;
    }

    #endregion
}
