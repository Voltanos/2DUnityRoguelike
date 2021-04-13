using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// This will restart the scene.
/// </summary>
[System.Serializable]
public class RestartScene : MonoBehaviour
{
    #region Monobehavior Methods

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    #endregion

    #region Member Methods

    private void CheckInput()
    {
        /////////////////////////////////////////
        //Local Variables

        FighterAttributes player;

        /////////////////////////////////////////

        player = ModelControl.GetPlayerAttributesFromModel();

        if (PlayerIsDead(player) == true)
        {
            if (AnyKeyPressed() == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private bool PlayerIsDead(FighterAttributes player)
    {
        if (player.CurrentHP <= 0)
        {
            return true;
        }

        return false;
    }

    private bool AnyKeyPressed()
    {
        if (Input.anyKey == true)
        {
            return true;
        }

        return false;
    }

    #endregion
}
