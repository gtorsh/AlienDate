using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class Global : MonoBehaviour
{

    public static DialogueContainer diaControl;
    public static progControl progControl;

    public enum pState
    {
        WALK,
        TALK,
        PAUSED
    }

    public static pState playerState;

    public static string green;
    public static string red;
    public static string blue;
    public static string yellow;
    public static string start;

    // Use this for initialization
    void Start()
    {
        ///=================================================///
        ///------------------Input from OS------------------///
        ///=================================================///
        switch (Application.platform)
        {
            case RuntimePlatform.LinuxEditor:
            case RuntimePlatform.LinuxPlayer:
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.WindowsEditor:
                if (Input.GetJoystickNames()[0] != "")
                {
                    green = "PCgreen";
                    red = "PCred";
                    blue = "PCblue";
                    yellow = "PCyellow";
                    start = "PCstart";
                }
                else
                {
                    green = "Kgreen";
                    red = "Kred";
                    blue = "Kblue";
                    yellow = "Kyellow";
                    start = "Kstart";
                }
                break;
            case RuntimePlatform.OSXPlayer:
            case RuntimePlatform.OSXEditor:
                print(Input.GetJoystickNames().Length);
                if (Input.GetJoystickNames().Length != 0)
                {
                    green = "OSXgreen";
                    red = "OSXred";
                    blue = "OSXblue";
                    yellow = "OSXyellow";
                    start = "OSXstart";
                }
                else
                {
                    green = "Kgreen";
                    red = "Kred";
                    blue = "Kblue";
                    yellow = "Kyellow";
                    start = "Kstart";
                }
                break;
            default:
                break;
        }
        print(Application.platform);
        print(green);
        print(red);
        print(blue);
        print(yellow);

        diaControl = DialogueContainer.Load("Assets/Data/Dialogue.xml");
        if (File.Exists(Application.dataPath + "/Saves/saveFile.xml"))
        {
            progControl = progControl.Load(Application.dataPath + "/Saves/saveFile.xml");
        } else
        {
            progControl = progControl.Load("Assets/Data/baseSaveFile.xml");
            progControl.Save();
        }
        playerState = pState.WALK;
    }

    // Update is called once per frame
    void Update() { }
}
