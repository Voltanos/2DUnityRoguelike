using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(TileMove))]
[RequireComponent(typeof(InputMove))]
public class InputAction : MonoBehaviour
{
    #region Member Variables

    private InputSettings MainInputSettings;

    private InputMove InputMove;

    private GameObject GameController;
    private GameObject GUIController;
    private GameObject MessageWindow;
    
    #endregion

    #region Monobehavior Events

    void Awake()
    {
        InputMove = GetComponent<InputMove>();

        GameController = GameObject.FindWithTag(TagKeys.MAIN_CONTROLLER_KEY);
        GUIController = GameObject.FindWithTag(TagKeys.GUI_CONTROLLER_KEY);
        MessageWindow = GameObject.FindWithTag(TagKeys.MESSAGE_WINDOW_KEY);

        MainInputSettings = ModelControl.GetInputSettingsFromModel();
    }

    void Update()
    {
        CheckForMainInputSettings();
        CheckState();
    }

    #endregion

    #region Private Methods

    private void CheckForMainInputSettings()
    {
        if (MainInputSettings != null)
        {
            return;
        }

        MainInputSettings = ModelControl.GetInputSettingsFromModel();
    }

    private void CheckState()
    {
        if (GameController == null)
        {
            GameController = GameObject.FindWithTag(TagKeys.MAIN_CONTROLLER_KEY);
        }

        else
        {
            if (GameController.GetComponent<GameStateController>().CurrentState == GameState.PLAYING)
            {
                DrawMessageWindowCheck();
                CheckInput();
            }
        }
    }

    private void CheckInput()
    {
        if (GUIController.GetComponent<GameMenuGUI>().DrawGUI == false)
        {            
            GameInput();
        }

        if (Input.GetKeyUp(MainInputSettings.MainMenu) == true)
        {
            if (GUIController.GetComponent<GameMenuGUI>().DrawGUI == false)
            {
                GUIController.GetComponent<GameMenuGUI>().DrawGUI = true;
            }

            else
            {
                GUIController.GetComponent<GameMenuGUI>().DrawGUI = false;
            }
        }
    }

    private void MoveDownCheck()
    {
        //////////////////////////////////////////////////
        //Local Variables

        GameObject ladder = GameObject.FindWithTag(TagKeys.LADDER_KEY);

        //////////////////////////////////////////////////

        if (ladder.transform.position != this.transform.position)
        {
            MessageWindow.GetComponent<MessageWindow>().AddText("There is no ladder underneath you!");
            return;
        }

        else
        {
            MessageWindow.GetComponent<MessageWindow>().AddText("You take a moment to rest, and recover your strength.");
            GetComponent<Fighter>().RestoreHP(Convert.ToInt32(GetComponent<Fighter>().Attributes.CurrentHP / 2));
            GameController.GetComponent<MapController>().ResetDungeon();
        }
    }

    private void DrawMessageWindowCheck()
    {
        if (Input.anyKeyDown == true)
        {
            if ((Input.GetKeyDown(MainInputSettings.MessageWindowScrollUp) == true) || (Input.GetKeyDown(MainInputSettings.MessageWindowScrollDown) == true))
            {
                MessageWindow.GetComponent<MessageWindow>().Draw = true;
            }

            else
            {
                MessageWindow.GetComponent<MessageWindow>().Draw = false;
            }
        }        

        if (Input.GetKeyUp(MainInputSettings.MessageWindowScrollUp) == true)
        {
            MessageWindow.GetComponent<MessageWindow>().IncrementListPosition();
            MessageWindow.GetComponent<MessageWindow>().Draw = true;
        }

        if (Input.GetKeyUp(MainInputSettings.MessageWindowScrollDown) == true)
        {
            MessageWindow.GetComponent<MessageWindow>().DecrementListPosition();
            MessageWindow.GetComponent<MessageWindow>().Draw = true;
        }
    }

    private void GameInput()
    {
        if (Input.GetKeyUp(MainInputSettings.MoveUp) == true)
        {
            InputMove.MoveTowards(MovementType.NORTH);
        }

        if (Input.GetKeyUp(MainInputSettings.MoveDown) == true)
        {
            InputMove.MoveTowards(MovementType.SOUTH);
        }

        if (Input.GetKeyUp(MainInputSettings.MoveLeft) == true)
        {
            InputMove.MoveTowards(MovementType.WEST);
        }

        if (Input.GetKeyUp(MainInputSettings.MoveRight) == true)
        {
            InputMove.MoveTowards(MovementType.EAST);
        }

        if (Input.GetKeyUp(MainInputSettings.OpenInventory) == true)
        {
            GUIController.GetComponent<GUIController>().SwitchInventory();
        }

        if (Input.GetKeyUp(MainInputSettings.OpenCharacterSheet) == true)
        {
            GUIController.GetComponent<GUIController>().SwitchCharacterSheet();
        }

        if (Input.GetKeyUp(MainInputSettings.GoDownLadder) == true)
        {
            MoveDownCheck();
        }
    }

    #endregion
}
