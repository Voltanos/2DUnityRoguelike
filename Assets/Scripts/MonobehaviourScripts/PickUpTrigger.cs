using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// This will check to see if the player has set off the trigger for this item, and mark it as picked up.
/// </summary>
public class PickUpTrigger : MonoBehaviour
{
    #region Member Variables

    public bool ItemPickedUp = false;

    #endregion

    #region Monobehaviour Methods

    void OnTriggerEnter(Collider collision)
    {
        PickUpCheck(collision.gameObject);
    }

    #endregion

    #region Member Methods

    private void PickUpCheck(GameObject entity)
    {
        //////////////////////////////////////////////////
        //Local Variables

        Point OUTSIDE = new Point(-100, -100);

        GameObject MainController;
        GameObject MessageWindow;

        ItemController controller;
        MainInventory inventory;

        //////////////////////////////////////////////////

        if (ItemPickedUp == true)
        {
            return;
        }

        MainController = GameObject.FindWithTag(TagKeys.MAIN_CONTROLLER_KEY);
        MessageWindow = GameObject.FindWithTag(TagKeys.MESSAGE_WINDOW_KEY);

        controller = MainController.GetComponent<ItemController>();
        inventory = MainController.GetComponent<MainInventory>();

        if (entity.tag.Equals(TagKeys.PLAYER_KEY) == true)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<TileMove>().SetTransform(OUTSIDE.x, OUTSIDE.y);
            inventory.AddItem(gameObject);

            MessageWindow.GetComponent<MessageWindow>().AddText(String.Format("Picked up {0}.", gameObject.name));

            controller.RemoveItem(gameObject);

            ItemPickedUp = true;

            //GetComponent<PreserveItemInInventory>().PreserveItem();
        }
    }

    #endregion
}
