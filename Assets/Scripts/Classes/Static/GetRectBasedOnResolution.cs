using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This static class will help with scaling the Rect object based on Resolution.
/// </summary>
public class GetRectBasedOnResolution
{
    public static Rect Start(Rect rectGUI)
    {
        try
        {
            return SetRect(rectGUI);
        }

        catch (Exception ex)
        {
            StaticTrace.Log(ex.Message);
            StaticTrace.Log(ex.StackTrace);
            return rectGUI;
        }
    }

    /// <summary>
    /// This will modify rectGUI to fit in the resolution.
    /// NOTE:  Algorithm based on this page.
    /// http://answers.unity3d.com/questions/307330/gui-scale-guis-according-to-resolution.html
    /// </summary>
    private static Rect SetRect(Rect rectGUI)
    {
        /////////////////////////////////////////////////////
        //Local Variables

        float screenWidth = 0.0f;
        float rectWidth = 0.0f;
        float screenHeight = 0.0f;
        float rectHeight = 0.0f;
        float rectX = 0.0f;
        float rectY = 0.0f;

        /////////////////////////////////////////////////////

        screenWidth = rectGUI.width / 800;
        rectWidth = screenWidth * Screen.width;

        screenHeight = rectGUI.height / 600;
        rectHeight = screenHeight * Screen.height;

        rectX = (rectGUI.x / 800) * Screen.width;
        rectY = (rectGUI.y / 600) * Screen.height;

        return new Rect(rectX, rectY, rectWidth, rectHeight);
    }
}

