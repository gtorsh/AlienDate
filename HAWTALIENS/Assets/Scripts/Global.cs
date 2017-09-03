using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.EventSystems;

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
        ///------------------Cursor Locked------------------///
        ///=================================================///
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ///=================================================///
        ///------------------Input from OS------------------///
        ///=================================================///
        switch (Application.platform)
        {
            case RuntimePlatform.LinuxEditor:
            case RuntimePlatform.LinuxPlayer:
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.WindowsEditor:
                if (Input.GetJoystickNames().Length != 0)
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
        EventSystem.current.GetComponent<StandaloneInputModule>().submitButton = green;
        EventSystem.current.GetComponent<StandaloneInputModule>().cancelButton = red;

        diaControl = DialogueContainer.Load(Application.streamingAssetsPath + "/Dialogue.xml");
        if (Directory.Exists(Application.dataPath + "/Saves"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Saves");
        }
        if (File.Exists(Application.dataPath + "/Saves/saveFile.xml"))
        {
            progControl = progControl.Load(Application.dataPath + "/Saves/saveFile.xml");
        } else
        {
            progControl = progControl.Load(Application.streamingAssetsPath + "/baseSaveFile.xml");
            progControl.Save();
        }
        playerState = pState.WALK;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("exit"))
        {
            switch (Cursor.visible)
            {
                case true:
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    break;
                case false:
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    break;
            }
        }
    }
}
