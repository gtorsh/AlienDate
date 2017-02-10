using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOver : MonoBehaviour {

    private int aButton, bButton, xButton, yButton, startButton;

    public bool inputUp = false;
    public bool inputDown = false;
    public bool inputLeft = false;
    public bool inputRight = false;

    public string OS;

    // Use this for initialization
    void Start()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsEditor:
                Debug.Log("You're in Windows");
                aButton = 330;
                bButton = 331;
                xButton = 332;
                yButton = 333;
                startButton = 7;
                break;
            case RuntimePlatform.OSXEditor:
                Debug.Log("You're in Mac");
                aButton = 346;
                bButton = 347;
                xButton = 348;
                yButton = 349;
                startButton = 9;
                break;
            default:
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        { 
                //Debug.Log("Fired");
        }
	}
}
