using UnityEngine;
using System.Collections;

public class ActivateText : MonoBehaviour {

	public TextBoxManager textBox;
	private bool waitforpress;

	// Use this for initialization
	void Start () 
	{
		textBox = FindObjectOfType<TextBoxManager> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (waitforpress && Input.GetKeyDown (KeyCode.E)) 
		{
			Debug.Log ("you definitely fired the script"); 
			textBox.loadConversation ();
			textBox.EnableTextBox ();
		}
	}

	void onCollisionEnter2D(Collider2D other)
	{
		Debug.Log ("You're in there");
		if (other.gameObject.tag == "Darrell") 
		{
			waitforpress = true;
		} 
	}

	void onTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Darrell") 
		{
			waitforpress = false;
		} 
	}
}
	 