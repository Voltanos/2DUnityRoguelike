using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TileMove))]
public class InputMove : MonoBehaviour
{
    #region Public Methods

    public void MoveTowards(MovementType move)
    {
        ///////////////////////////////////////
        //Local Variables

        Vector3 newPosition;

        GameObject other;
        TileMove tileMove = GetComponent<TileMove>();
        GameObject mainController = GameObject.FindWithTag(TagKeys.MAIN_CONTROLLER_KEY); ;

        InputAttack attack = GetComponent<InputAttack>();

        ///////////////////////////////////////

        if (mainController.GetComponent<GameStateController>().CurrentTurnState != TurnState.PLAYER_TURN)
        {
            return;
        }

        newPosition = GetNewPosition(move);
        other = tileMove.TryMove(newPosition);

        if (other != null)
        {
            attack.AttackCheck(other);
        }
    }

    #endregion

    #region Private Methods

    private Vector3 GetNewPosition(MovementType move)
    {
        //////////////////////////////////////////////////
        //Local Variables

        Vector3 newPosition = new Vector3();

        //////////////////////////////////////////////////

        switch (move)
        {
            case MovementType.NORTH:
                newPosition = new Vector3(transform.position.x, transform.position.y + 1, 0.0f);
                break;

            case MovementType.EAST:
                newPosition = new Vector3(transform.position.x + 1, transform.position.y, 0.0f);
                break;

            case MovementType.SOUTH:
                newPosition = new Vector3(transform.position.x, transform.position.y - 1, 0.0f);
                break;

            case MovementType.WEST:
                newPosition = new Vector3(transform.position.x - 1, transform.position.y, 0.0f);
                break;
        }

        return newPosition;
    }

    #endregion
}
