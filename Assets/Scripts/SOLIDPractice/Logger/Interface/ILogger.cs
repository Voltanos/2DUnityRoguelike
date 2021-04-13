using System.Collections;
using System.Collections.Generic;

public interface ILogger
{
    void Log(string message);
    void ExceptionLog(string message, string stackTrace);
}
