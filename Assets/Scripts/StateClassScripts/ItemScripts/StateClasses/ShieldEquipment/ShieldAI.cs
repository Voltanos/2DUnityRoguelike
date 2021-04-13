using UnityEngine;
using System;
using System.Collections;

[System.Serializable]
public class ShieldAI : AbstractItemAI
{
    #region Member Variables

    private Boolean IsEquipped;

    #endregion

    #region Member Methods

    override public void Enter(GameObject main)
    {
        this.OnUseCheck = false;
        this.OnEquipCheck = true;
        this.OnUnequipCheck = true;
        this.OnDropCheck = true;
        this.OnTargetCheck = false;

        this.Attributes = NewShieldAttributes.Start();

        this.Slot = EquipmentSlotState.SHIELD;

        this.IsEquipped = false;

        return;
    }

    override public void Exit(GameObject main)
    {
        return;
    }

    override public void OnUse(GameObject main, GameObject itemTarget)
    {

    }

    override public void OnEquip(GameObject main, GameObject itemTarget)
    {
        ///////////////////////////////////////////////////////
        //Local Variables

        GameObject messageWindow = GameObject.FindWithTag(TagKeys.MESSAGE_WINDOW_KEY);

        ///////////////////////////////////////////////////////

        if (this.IsEquipped == true)
        {
            return;
        }

        itemTarget.GetComponent<Fighter>().Attributes.ItemEquip(this);

        messageWindow.GetComponent<MessageWindow>().AddText(String.Format("Equipped {0}.", main.name));

        main.name = String.Format("{0} (E)", main.name);

        this.IsEquipped = true;
    }

    override public void OnUnequip(GameObject main, GameObject itemTarget)
    {
        ////////////////////////////////////////////////////////////
        //Local Variables

        GameObject messageWindow = GameObject.FindWithTag(TagKeys.MESSAGE_WINDOW_KEY);

        ////////////////////////////////////////////////////////////

        this.IsEquipped = false;

        itemTarget.GetComponent<Fighter>().Attributes.ItemUnequip(this.Slot);

        main.name = main.name.Split(' ')[0];

        messageWindow.GetComponent<MessageWindow>().AddText(String.Format("Unequipped {0}.", main.name));
    }

    override public void OnDrop(GameObject main, GameObject itemTarget)
    {
        DestroyItem(main);
    }

    public override void OnTarget(GameObject main, GameObject itemTarget)
    {

    }

    public override void OnExamine(GameObject main)
    {
        /////////////////////////////////////////////////////////////
        //Local Variables

        GameObject messageWindow = GameObject.FindWithTag(TagKeys.MESSAGE_WINDOW_KEY);

        /////////////////////////////////////////////////////////////

        messageWindow.GetComponent<MessageWindow>().AddText(EquipmentExamineMessage.Start(this.Attributes));
    }

    private void DestroyItem(GameObject main)
    {
        ///////////////////////////////////////
        //Local Variables

        GameObject mainController;

        ///////////////////////////////////////

        mainController = GameObject.FindWithTag(TagKeys.MAIN_CONTROLLER_KEY);

        mainController.GetComponent<MainInventory>().RemoveItem(main);
        UnityEngine.Object.Destroy(main);
    }

    #endregion
}
