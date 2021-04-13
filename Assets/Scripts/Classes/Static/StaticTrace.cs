using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// This is a static class version of my "Debugger" class.
/// </summary>
public static class StaticTrace
{
    public static void Log(string message)
    {
        /////////////////////////////////////////////
        //Local Variables

        string logMessage;

        /////////////////////////////////////////////

        logMessage = string.Format("{0}:  {1}", DateTime.Now.TimeOfDay.ToString(), message);

        Debug.Log(logMessage);
    }

    public static void ExceptionLog(string message, string stackTrace)
    {
        /////////////////////////////////////////////
        //Local Variables

        string logMessage;

        /////////////////////////////////////////////

        logMessage = string.Format("{0}:  {1} || {2}", DateTime.Now.TimeOfDay.ToString(), message, stackTrace);

        Debug.Log(logMessage);
    }
}
