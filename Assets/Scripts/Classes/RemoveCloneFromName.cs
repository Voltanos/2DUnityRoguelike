using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This will remove the "(Clone)" tag from a given name, and return it.
/// </summary>
public static class RemoveCloneFromName
{
    #region Member Variables

    private const string CLONE_TAG = "(Clone)";

    #endregion

    public static string Start(string name)
    {
        try
        {
            return RemoveTag(name);
        }

        catch (Exception ex)
        {
            StaticTrace.Log(ex.Message);
            StaticTrace.Log(ex.StackTrace);
            return name;
        }
    }

    private static string RemoveTag(string name)
    {
        ///////////////////////////////////////////////////////////
        //Local Variables

        string result;

        ///////////////////////////////////////////////////////////

        result = name.Replace(CLONE_TAG, "");

        return result;
    }
}
