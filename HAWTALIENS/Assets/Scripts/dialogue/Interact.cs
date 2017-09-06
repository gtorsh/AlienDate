using UnityEngine;
using System.Collections;
using System;

public class Interact : MonoBehaviour {

	public GameObject TextImporter;
	public TextBoxManager textBox;

    public bool selfText;
    public string text;
    public string actors;
    public string selfFlags;
    public bool canTake;

	public bool waitforpress;
    public bool popupTrue;

	// Use this for initialization
	void Start () 
	{
        TextImporter = GameObject.FindGameObjectWithTag("TextImporterParent").transform.GetChild(0).gameObject;
        if (selfText)
        {
            if (text == null || text == "")
            {
                print("Dude, You left selfText on!");
            }
        }
	}

    // Update is called once per frame
    void Update() {
        if (waitforpress == true && Input.GetButtonDown(Global.green))
        {
            switch (Global.playerState)
            {
                case (Global.pState.WALK):
                    talk();
                    break;
                case (Global.pState.TALK):
                    break;
                case (Global.pState.PAUSED):
                    break;
            }
        }
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Darrell") 
		{
            waitforpress = true;
            popupTrue = true;
		} 
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Darrell") 
		{
			waitforpress = false;
            popupTrue = false;
		} 
	}

    public void talk()
    {
        if (waitforpress == true)
        {
            Global.playerState = Global.pState.TALK;
            TextImporter.SetActive(true);
            textBox = FindObjectOfType<TextBoxManager>();
            if (!selfText)
            {
                textBox.Character = gameObject.name;
                textBox.selfText = false;
                textBox.selfTextBulk = "";
                textBox.selfTextActorBulk = "";
                textBox.selfTextFunction();
                textBox.canTake = false;
            }
            else
            {
                textBox.Character = gameObject.name;
                textBox.selfText = true;
                textBox.selfTextBulk = text;
                textBox.selfTextActorBulk = actors;
                textBox.selfTextFunction();
                textBox.canTake = canTake;
            }
            if (textBox.isActive == false)
            {
                textBox.EnableTextBox();
            }
        }
    }
}
	 