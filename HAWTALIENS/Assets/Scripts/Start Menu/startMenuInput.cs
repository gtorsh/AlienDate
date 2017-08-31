using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class startMenuInput : MonoBehaviour {

    private GameObject tempObject;

    // Use this for initialization
    void Start () {
        tempObject = EventSystem.current.GetComponent<EventSystem>().currentSelectedGameObject;
    }
	
	// Update is called once per frame
	void Update () {
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
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            Button tempButton = tempObject.GetComponent<Button>();
            tempButton.OnSelect(null);
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(tempObject);
        }
        if (EventSystem.current.GetComponent<EventSystem>().currentSelectedGameObject != tempObject && EventSystem.current.GetComponent<EventSystem>().currentSelectedGameObject != null)
        {
            tempObject = EventSystem.current.GetComponent<EventSystem>().currentSelectedGameObject;
        }
    }
}
