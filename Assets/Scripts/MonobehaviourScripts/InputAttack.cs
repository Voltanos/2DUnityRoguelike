using UnityEngine;
using System.Collections;

public class InputAttack : MonoBehaviour
{
    #region Public Methods

    public void AttackCheck(GameObject monster)
    {
        //////////////////////////////////////////
        //Local Variables

        GameObject mainController = GameObject.FindWithTag(TagKeys.MAIN_CONTROLLER_KEY);

        //////////////////////////////////////////

        //GameControllerIsNotNull();

        if (mainController.GetComponent<GameStateController>().CurrentTurnState != TurnState.PLAYER_TURN)
        {
            return;
        }

        if (monster.GetComponent<Tile>().Type != TileType.TILE_NPC)
        {
            return;
        }

        Attack(monster);
    }

    #endregion

    #region Private Methods

    private void Attack(GameObject monster)
    {
        ///////////////////////////////////////////
        //Local Variables

        PlayerActions actionController = GetComponent<PlayerActions>();

        Fighter myFighter;

        ///////////////////////////////////////////

        myFighter = GetComponent<Fighter>();
        myFighter.AttackTarget(monster);

        actionController.ActionPerformed();
    }

    #endregion
}
