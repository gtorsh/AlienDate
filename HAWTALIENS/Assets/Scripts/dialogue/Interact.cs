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
	void Update () {
		if (waitforpress == true && Input.GetKeyDown (KeyCode.E)) 
		{
			TextImporter.SetActive (true);
			textBox = FindObjectOfType<TextBoxManager> ();
            textBox.Character = gameObject.name;
            textBox.EnableTextBox ();
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
}
	 