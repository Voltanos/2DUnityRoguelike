using UnityEngine;
using System.Collections;

/// <summary>
/// This will manage all the possible actions a player can perform, and eventually end their turn.
/// </summary>
public class PlayerActions : MonoBehaviour
{
    #region Member Variables

    public int MaxActions = 1;

    private int BaseActions = 0;

    #endregion

    #region Public Methods

    public void ActionPerformed()
    {
        ///////////////////////////////////////////////
        //Local Variables

        GameObject mainController = GameObject.FindWithTag(TagKeys.MAIN_CONTROLLER_KEY);

        ///////////////////////////////////////////////

        //GameControllerIsNotNull();

        BaseActions -= 1;

        if (BaseActions <= 0)
        {
            mainController.GetComponent<GameStateController>().IncrementTurnState();
            BaseActions = MaxActions;
        }
    }

    public void IncrementAction(int value = 1)
    {
        BaseActions += value;
    }

    #endregion
}
