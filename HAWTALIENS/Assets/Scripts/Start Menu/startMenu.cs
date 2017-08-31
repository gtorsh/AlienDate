using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startMenu : MonoBehaviour {

    public Button startGame;
    public Button loadGame;
    public Button exitGame;
    
    public string green, red, blue, yellow, start;

	// Use this for initialization
	void Start ()
    {
        startGame = startGame.GetComponent<Button>();
        loadGame = loadGame.GetComponent<Button>();
        exitGame = exitGame.GetComponent<Button>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

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
        EventSystem.current.GetComponent<StandaloneInputModule>().submitButton = green;
        EventSystem.current.GetComponent<StandaloneInputModule>().cancelButton = red;
    }

    void update ()
    {
        
    }

	
	public void startPress()
    {
        SceneManager.LoadScene("Test");
    }

    public void exitPress()
    {
        Application.Quit();
    }
}
