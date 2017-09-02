using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

	public GameObject TextImporter;
	public TextBoxManager textBox;
	public bool waitforpress;
    public bool popupTrue;

	// Use this for initialization
	void Start () 
	{
        //diaControl.Save("Assets/Data/Dialogue.xml");
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
            textBox.Character = gameObject.name;
            if (textBox.isActive == false)
            {
                textBox.EnableTextBox();
            }
        }
    }
}
	 