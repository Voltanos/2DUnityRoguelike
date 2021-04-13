using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameStateController : MonoBehaviour
{
    #region Member Variables

    public GameState CurrentState;
    public TurnState CurrentTurnState;

    #endregion

    #region Monobehavior Events

    //For Initializeation.
    void Awake()
    {
        CurrentState = GameState.PLAYING;
        CurrentTurnState = TurnState.PLAYER_TURN;
    }

    #endregion

    #region Member Methods

    public void IncrementTurnState()
    {
        switch (CurrentTurnState)
        {
            case TurnState.PLAYER_TURN:
                CurrentTurnState = TurnState.ENEMY_TURN;
                break;

            case TurnState.ENEMY_TURN:
                CurrentTurnState = TurnState.PLAYER_TURN;
                break;

            default:
                break;
        }
    }

    #endregion
}
