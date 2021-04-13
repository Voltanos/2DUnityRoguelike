using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Logger : ILogger
{
    #region Public Methods

    public void Log(string message)
    {
        /////////////////////////////////////////////
        //Local Variables

        string logMessage;

        /////////////////////////////////////////////

        logMessage = string.Format("{0}:  {1}", DateTime.Now.TimeOfDay.ToString(), message);

        Debug.Log(logMessage);
    }

    public void ExceptionLog(string message, string stackTrace)
    {
        /////////////////////////////////////////////
        //Local Variables

        string logMessage;

        /////////////////////////////////////////////

        logMessage = string.Format("{0}:  {1} || {2}", DateTime.Now.TimeOfDay.ToString(), message, stackTrace);

        Debug.Log(logMessage);
    }

    #endregion
}
