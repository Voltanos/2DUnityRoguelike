using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This will create the item's for the player's inventory, and return it.
/// </summary>
public class CreatePlayerInventoryFactory
{
    #region Member Variables

    public List<AbstractItemAI> InventoryAIList { get; set; }

    private Dictionary<string, GameObject> PrefabDictionary { get; set; }

    #endregion

    #region Constructors

    public CreatePlayerInventoryFactory()
    {
        this.InventoryAIList = null;
        this.PrefabDictionary = new Dictionary<string, GameObject>();

        CreateDictionary();
    }

    #endregion

    #region Public Methods

    public List<GameObject> Create()
    {
        return CreationCheck();
    }

    #endregion

    #region Private Methods

    private List<GameObject> CreationCheck()
    {
        if (ValidBuild() == false)
        {
            throw new Exception("Some of the parameters for 'CreatePlayerInventoryFactory' are null.  Build terminated.");
        }

        return CreateList();
    }

    private List<GameObject> CreateList()
    {
        /////////////////////////////////////////////
        //Local Variables

        List<GameObject> itemList = new List<GameObject>();

        /////////////////////////////////////////////

        foreach (AbstractItemAI itemAI in this.InventoryAIList)
        {
            itemList.Add(CreateItem(itemAI));
        }

        return itemList;
    }

    private GameObject CreateItem(AbstractItemAI itemAI)
    {
        /////////////////////////////////////////////////
        //Local Variables

        GameObject item;

        /////////////////////////////////////////////////

        item = UnityEngine.Object.Instantiate(this.PrefabDictionary[itemAI.ItemName]) as GameObject;

        item.GetComponent<ItemAI>().ChangeState(itemAI);

        item.GetComponent<PreserveItemInInventory>().PreserveItem();

        item.name = RemoveCloneFromName.Start(item.name);

        return item;
    }

    private bool ValidBuild()
    {
        ///////////////////////////////////////////
        //Local Variables

        bool results = false;

        ///////////////////////////////////////////

        if (
                (this.InventoryAIList != null)
           )
        {
            results = true;
        }

        return results;
    }

    private void CreateDictionary()
    {
        ////////////////////////////////////////////////////
        //Local Variables

        GameObject confusionScroll;
        GameObject fireballScroll;
        GameObject lightningBoltScroll;
        GameObject potion;
        GameObject shield;
        GameObject sword;

        ////////////////////////////////////////////////////

        confusionScroll = (GameObject)Resources.Load("Confusion Scroll", typeof(GameObject));
        fireballScroll = (GameObject)Resources.Load("Fireball Scroll", typeof(GameObject));
        lightningBoltScroll = (GameObject)Resources.Load("Lightning Bolt Scroll", typeof(GameObject));
        potion = (GameObject)Resources.Load("Potion", typeof(GameObject));
        shield = (GameObject)Resources.Load("BaseShield", typeof(GameObject));
        sword = (GameObject)Resources.Load("BaseSword", typeof(GameObject));

        this.PrefabDictionary.Add(confusionScroll.name, confusionScroll);
        this.PrefabDictionary.Add(fireballScroll.name, fireballScroll);
        this.PrefabDictionary.Add(lightningBoltScroll.name, lightningBoltScroll);
        this.PrefabDictionary.Add(potion.name, potion);
        this.PrefabDictionary.Add(shield.name, shield);
        this.PrefabDictionary.Add(sword.name, sword);
    }

    #endregion
}
