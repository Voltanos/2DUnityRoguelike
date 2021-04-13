using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/// <summary>
/// This static class will save and load the game.
/// </summary>
public static class SaveLoad
{
    #region Public Static Methods

    /// <summary>
    /// This will save the game.
    /// </summary>
    public static void Save()
    {
        ////////////////////////////////////////////////
        //Local Variables

        SerializerRepository repository;

        ////////////////////////////////////////////////

        repository = LoadRepository();

        repository.Save();
    }

    /// <summary>
    /// This will load the game.
    /// </summary>
    public static void Load()
    {
        ////////////////////////////////////////////////
        //Local Variables

        SerializerRepository repository;

        ////////////////////////////////////////////////

        repository = LoadRepository();

        repository.Load();
    }

    #endregion

    #region Private Methods

    private static SerializerRepository LoadRepository()
    {
        ////////////////////////////////////////////////////
        //Local Variables

        SerializerRepository repository;

        ////////////////////////////////////////////////////

        repository = new SerializerRepository(ModelControl.ReturnModel());

        return repository;
    }

    #endregion
}

