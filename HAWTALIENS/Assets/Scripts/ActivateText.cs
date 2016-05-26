using UnityEngine;
using System.Collections;

public class ActivateText : MonoBehaviour {

	public GameObject TextImporter;
	public TextBoxManager textBox;
	private bool waitforpress;

	// Use this for initialization
	void Start () 
	{
			
	}
	
	// Update is called once per frame
	void Update () {
		if (waitforpress == true && Input.GetKeyDown (KeyCode.E)) 
		{
			TextImporter.SetActive (true);
			textBox = FindObjectOfType<TextBoxManager> ();
			Debug.Log ("you definitely fired the script"); 
			textBox.loadConversation ();
			textBox.EnableTextBox ();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("You're in there");
		if (other.gameObject.tag == "Darrell") 
		{
			waitforpress = true;
		} 
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Darrell") 
		{
			Debug.Log ("You're out of there");
			waitforpress = false;
		} 
	}
}
	 