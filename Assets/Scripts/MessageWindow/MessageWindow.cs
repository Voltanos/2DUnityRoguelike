using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MessageWindow : MonoBehaviour
{
    #region Member Variables

    private int ListPosition = 0;

    public bool Draw = false;

    private List<string> MessageList = new List<string>();

    public int MaxSize = 100;

    public GUILabel MainLabel;

    public GUIBox MainBox;

    #endregion

    #region Monobehaviour Methods.

    // Update is called once per frame
    void OnGUI()
    {
        DrawCheck();
    }

    #endregion

    #region Member Methods    

    public void AddText(string message)
    {
        RemoveMessage();
        MessageList.Add(message);

        if (Draw == false)
        {
            ListPosition = MessageList.Count - 1;
        }

        Draw = true;
    }

    public void DecrementListPosition()
    {
        ListPosition -= 1;

        if (ListPosition < 0)
        {
            ListPosition = 0;
        }
    }

    public void IncrementListPosition()
    {
        ListPosition += 1;

        if (ListPosition >= MessageList.Count)
        {
            ListPosition = MessageList.Count - 1;
        }
    }

    #endregion

    #region Private Methods

    private void RemoveMessage()
    {
        ///////////////////////////////////////
        //Local Variables

        bool lContinue = true;

        ///////////////////////////////////////

        if (MessageList.Count >= MaxSize)
        {
            while (lContinue == true)
            {
                MessageList.RemoveAt(0);
                ListPosition -= 1;

                if (MessageList.Count < MaxSize)
                {
                    lContinue = false;
                }
            }
        }
    }

    private void DrawCheck()
    {
        if ((Draw == true) && (MessageList.Count > 0))
        {
            UpdateLabelBorders();

            MainLabel.Content.text = ParseTextHeight();

            MainBox.Draw();
            MainLabel.Draw();
        }
    }

    private string ParseTextHeight()
    {
        ///////////////////////////////////////////
        //Local Variables

        const int BASE_POSITION = 10;

        const string NEW_LINE = "\n";

        int i = 0;

        GUIStyle calculator = new GUIStyle();

        Vector2 tempLineSize = new Vector2();

        string line = "";
        string row = "";

        ///////////////////////////////////////////

        for (i = ListPosition; i < MessageList.Count; i += 1)
        {
            row = ParseTextWidth(MessageList[i]);

            tempLineSize = calculator.CalcSize(new GUIContent(line + row));

            if (tempLineSize.y > MainBox.FinalBox.height - BASE_POSITION)
            {
                break;
            }

            else
            {
                line += row + NEW_LINE;
            }
        }

        return line;
    }

    private string ParseTextWidth(string message)
    {
        ////////////////////////////////////////
        //Local Variables

        const int BASE_POSITION = 10;

        const string NEW_LINE = "\n";
        const string SPACE = " ";

        string line = "";
        string returnLine = "";

        GUIStyle calculator = new GUIStyle();

        Vector2 tempLineSize = new Vector2();

        string[] wordArray;

        ////////////////////////////////////////

        wordArray = message.Split(' ');

        foreach (string word in wordArray)
        {
            tempLineSize = calculator.CalcSize(new GUIContent(line + word));

            if (tempLineSize.x > MainBox.FinalBox.width - BASE_POSITION)
            {
                returnLine += line + NEW_LINE;
                line = "";
            }

            line += word + SPACE;
        }

        returnLine += line;
        return returnLine;
    }

    private void UpdateLabelBorders()
    {
        MainLabel.BaseBox.x = MainBox.BaseBox.x + 10;
        MainLabel.BaseBox.y = MainBox.BaseBox.y;
        MainLabel.BaseBox.width = MainBox.BaseBox.width - 10;
        MainLabel.BaseBox.height = MainBox.BaseBox.height;
    }

    #endregion
}
