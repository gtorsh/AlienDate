using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class Global : MonoBehaviour {

    public static DialogueContainer diaControl;

    public enum pState
    {
        WALK,
        TALK,
        PAUSED
    }

    public static pState playerState;

    public string green;
    public string red;
    public string blue;
    public string yellow;

    // Use this for initialization
    void Start () {
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
                } else
                {
                    green = "Kgreen";
                    red = "Kred";
                    blue = "Kblue";
                    yellow = "Kyellow";
                }
                break;
            case RuntimePlatform.OSXPlayer:
            case RuntimePlatform.OSXEditor:
                if (Input.GetJoystickNames()[0] != "")
                {
                    green = "OSXgreen";
                    red = "OSXred";
                    blue = "OSXblue";
                    yellow = "OSXyellow";
                }
                else
                {
                    green = "Kgreen";
                    red = "Kred";
                    blue = "Kblue";
                    yellow = "Kyellow";
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
        playerState = pState.WALK;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SaveData()
    {
        if (!Directory.Exists("Saves"))
            Directory.CreateDirectory("Saves");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create("Saves/save.binary");
        var LocalCopyOfData = 0;
    }
}
