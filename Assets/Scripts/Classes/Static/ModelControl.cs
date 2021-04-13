using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This will get the model to be referenced in the project.
/// </summary>
public static class ModelControl
{
    #region Public Methods

    public static MainAggregate ReturnModel()
    {
        try
        {
            return FindAndReturnModel();
        }

        catch (Exception ex)
        {
            StaticTrace.ExceptionLog(ex.Message, ex.StackTrace);
            return null;
        }
    }

    public static void UpdateModel(MainAggregate updatedAggregate)
    {
        try
        {
            FindAndUpdateModel(updatedAggregate);
        }

        catch (Exception ex)
        {
            StaticTrace.ExceptionLog(ex.Message, ex.StackTrace);
        }
    }

    public static FighterAttributes GetPlayerAttributesFromModel()
    {
        try
        {
            return GetFighterAttributes();
        }

        catch (Exception ex)
        {
            StaticTrace.ExceptionLog(ex.Message, ex.StackTrace);
            return null;
        }
    }

    public static void UpdatePlayerAttributesInModel(FighterAttributes attributes)
    {
        try
        {
            UpdateFighterAttributes(attributes);
        }

        catch (Exception ex)
        {
            StaticTrace.ExceptionLog(ex.Message, ex.StackTrace);
        }
    }

    public static List<AbstractItemAI> GetItemListFromModel()
    {
        try
        {
            return GetItemList();
        }

        catch (Exception ex)
        {
            StaticTrace.ExceptionLog(ex.Message, ex.StackTrace);
            return null;
        }
    }

    public static InputSettings GetInputSettingsFromModel()
    {
        try
        {
            return GetInputSettings();
        }

        catch (Exception ex)
        {
            StaticTrace.ExceptionLog(ex.Message, ex.StackTrace);
            return null;
        }
    }

    #endregion

    #region Private Methods

    private static void FindAndUpdateModel(MainAggregate updatedAggregate)
    {
        GameObject.FindWithTag(TagKeys.MODEL_KEY).GetComponent<Aggregate>().Model = updatedAggregate;
    }

    private static InputSettings GetInputSettings()
    {
        /////////////////////////////////////////////////////
        //Local Variables

        MainAggregate model;

        /////////////////////////////////////////////////////

        model = FindAndReturnModel();

        return model.InputSettings;
    }

    private static List<AbstractItemAI> GetItemList()
    {
        /////////////////////////////////////////////////////
        //Local Variables

        MainAggregate model;

        /////////////////////////////////////////////////////

        model = FindAndReturnModel();

        return model.InventoryAIList;
    }

    private static FighterAttributes GetFighterAttributes()
    {
        /////////////////////////////////////////////////////
        //Local Variables

        MainAggregate model;

        /////////////////////////////////////////////////////

        model = FindAndReturnModel();

        return model.PlayerAttributes;
    }

    private static void UpdateFighterAttributes(FighterAttributes attributes)
    {
        /////////////////////////////////////////////////////
        //Local Variables

        MainAggregate model;

        /////////////////////////////////////////////////////

        model = FindAndReturnModel();

        model.PlayerAttributes = attributes;
    }

    private static MainAggregate FindAndReturnModel()
    {
        if (GameObjectWithAggregateExists() == false)
        {
            throw new Exception("The Game object with the Aggregate does not exist!");
        }

        return GameObject.FindWithTag(TagKeys.MODEL_KEY).GetComponent<Aggregate>().Model;
    } 
    
    private static bool GameObjectWithAggregateExists()
    {
        /////////////////////////////////////////////////////
        //Local Variables

        GameObject aggregateContainer;

        /////////////////////////////////////////////////////

        aggregateContainer = GameObject.FindWithTag(TagKeys.MODEL_KEY);

        if (aggregateContainer == null)
        {
            return false;
        }

        return true;
    }

    #endregion
}