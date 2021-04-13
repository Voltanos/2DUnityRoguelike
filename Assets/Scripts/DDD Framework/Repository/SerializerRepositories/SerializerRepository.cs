using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// This is the main repository for the "MainAggregate".
/// </summary>
public class SerializerRepository
{
    #region Member Variables

    const string FILE_NAME = "SavedGames.gd";

    private MainAggregate Aggregate;

    #endregion

    #region Constructors

    public SerializerRepository(MainAggregate aggregate)
    {
        this.Aggregate = aggregate;
    }

    #endregion

    #region Public Methods

    public void Save()
    {
        SaveAggregate();
    }

    public void Load()
    {
        LoadAggregate();
    }

    #endregion

    #region Private Methods

    private void LoadAggregate()
    {
        ///////////////////////////////////////////////////////
        //Local Variables

        MainAggregate aggregate;

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream file;

        string filePath = "";

        ///////////////////////////////////////////////////////

        filePath = CheckIfFileExists();

        if (filePath == null)
        {
            return;
        }

        file = File.Open(filePath, FileMode.Open);
        aggregate = (MainAggregate)formatter.Deserialize(file);
        file.Close();

        ModelControl.UpdateModel(aggregate);
    }

    private void SaveAggregate()
    {
        /////////////////////////////////////////////////////
        //Local Variables

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream file;

        string filePath = "";

        /////////////////////////////////////////////////////

        filePath = GetFilePath();

        file = File.Create(filePath);

        formatter.Serialize(file, this.Aggregate);

        StaticTrace.Log(String.Format("File saved at '{0}'.", filePath));

        file.Close();
    }

    private string CheckIfFileExists()
    {
        ///////////////////////////////////////////////////////
        //Local Variables

        string filePath = "";

        ///////////////////////////////////////////////////////

        filePath = GetFilePath();

        if (File.Exists(filePath) == false)
        {
            return null;
        }

        return filePath;
    }

    private string GetFilePath()
    {
        ///////////////////////////////////////////////////////
        //Local Variables

        string filePath = "";

        ///////////////////////////////////////////////////////

        filePath = String.Format("{0}/{1}", Application.persistentDataPath, FILE_NAME);

        return filePath;
    }

    #endregion
}
