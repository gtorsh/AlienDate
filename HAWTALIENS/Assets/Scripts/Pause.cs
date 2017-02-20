using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public Button contButton;
    public Button optionsButton;
    public Button exitButton;

    private GameObject tempObject;

    public bool isActive;

	// Use this for initialization
	void Start () {
        isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		switch (Global.playerState)
        {
            case (Global.pState.PAUSED):
                if (Input.GetButtonDown(Global.start))
                {
                    continuePress();
                }
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
                {
                    EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(tempObject);
                }
                break;
            default:
                break;
        }
        if (EventSystem.current.GetComponent<EventSystem>().currentSelectedGameObject != tempObject && EventSystem.current.GetComponent<EventSystem>().currentSelectedGameObject != null)
        {
            tempObject = EventSystem.current.GetComponent<EventSystem>().currentSelectedGameObject;
        }
    }

    void OnEnable()
    {
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(contButton.gameObject);
        contButton.OnSelect(null);
        tempObject = contButton.gameObject;
    }

    public void exitPress()
    {
        Time.timeScale = 1;
        var mObj = GameObject.Find("Darrell");
        mObj.GetComponent<Movement>().pMenu.SetActive(false);
        mObj.GetComponent<Movement>().canMove = true;
        Global.playerState = mObj.GetComponent<Movement>().tpState;
        isActive = false;
        SceneManager.LoadScene("Main Menu");
    }

    public void continuePress()
    {
        Time.timeScale = 1;
        var mObj = GameObject.Find("Darrell");
        mObj.GetComponent<Movement>().pMenu.SetActive(false);
        mObj.GetComponent<Movement>().canMove = true;
        Global.playerState = mObj.GetComponent<Movement>().tpState;
        isActive = false;
    }
}
