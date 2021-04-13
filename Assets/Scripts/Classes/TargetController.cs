using UnityEngine;
using System.Collections;

public class TargetController : MonoBehaviour
{
    #region Member Variables

    public KeyCode SELECT_TARGET = KeyCode.Mouse0;
    public KeyCode CANCEL_TARGET = KeyCode.Mouse1;

    public TargetingState TargetState;

    public GameObject ObjectControl;
    public GameObject Player;

    private GameObject MessageWindow;

    public int Distance;

    public bool TargetReady = false;
    public bool UpdateReady = false;

    #endregion

    #region MonoBehaviour Events

    void Awake()
    {
        MessageWindow = GameObject.FindWithTag(TagKeys.MESSAGE_WINDOW_KEY);

        Player = GameObject.FindWithTag(TagKeys.PLAYER_KEY);
    }

    void Update()
    {
        CheckState();
    }

    #endregion

    #region Member Methods

    public void StartTarget(TargetingState tempState, int tempDistance, GameObject objectControl)
    {
        TargetState = tempState;
        Distance = tempDistance;
        ObjectControl = objectControl;

        Player.GetComponent<InputAction>().enabled = false;

        MessageWindow.GetComponent<MessageWindow>().AddText("Please select a target.");
        TargetReady = true;
    }

    private void CheckState()
    {
        if (TargetReady == true)
        {
            if (UpdateReady == true)
            {
                CheckInput();
            }

            if (UpdateReady == false)
            {
                UpdateReady = true;
            }
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyUp(SELECT_TARGET) == true)
        {
            CheckTarget();
        }

        if (Input.GetKeyUp(CANCEL_TARGET) == true)
        {
            MessageWindow.GetComponent<MessageWindow>().AddText("Canceling target.");
            CancelTarget();
        }
    }

    private void CheckTarget()
    {
        //////////////////////////////////////////////////////
        //Local Variables

        GameObject target;

        Fighter fighterComp;

        bool withinDistance = false;

        //////////////////////////////////////////////////////

        target = GetGameObjectViaMouse.Start();

        if (target == null)
        {
            MessageWindow.GetComponent<MessageWindow>().AddText("No target selected.  Please select a target.");
            return;
        }

        fighterComp = target.GetComponent<Fighter>();

        if (fighterComp == null)
        {
            MessageWindow.GetComponent<MessageWindow>().AddText("No target selected.  Please select a target.");
            return;
        }

        withinDistance = Validator.TargetNearPlayer(target, Distance);

        if (withinDistance == false)
        {
            MessageWindow.GetComponent<MessageWindow>().AddText("Target not within range.  Please select a target.");
            return;
        }

        CheckOnTarget(target);
    }

    private void CheckOnTarget(GameObject target)
    {
        if (TargetState == TargetingState.ITEM_TARGET)
        {
            ObjectControl.GetComponent<ItemAI>().OnTarget(target);
        }

        if (TargetState == TargetingState.SPELL_TARGET)
        {
            //Does nothing.
        }

        CancelTarget();
    }

    private void CancelTarget()
    {
        Player.GetComponent<InputAction>().enabled = true;

        Destroy(gameObject);
    }

    #endregion
}
