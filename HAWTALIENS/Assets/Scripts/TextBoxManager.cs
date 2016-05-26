using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;
using System.IO;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;

	public Text theText;

	public string Conversation;
	public string Character; 
	public string[] textLines;
	private static string myFile;

	public int currentLine;
	public int endAtLine;

	public Movement player;

	public bool isActive;

		// Use this for initialization
	void Start () 
	{
		player = FindObjectOfType<Movement> ();
		loadConversation();
	}


	// Update is called once per frame
	void Update () 
	{

		if(Input.GetKeyDown(KeyCode.Space)) 
		{
			currentLine += 1;
		}

		if (currentLine <= endAtLine) 
		{
			theText.text = textLines [currentLine];
		} else {
			DisableTextBox ();
		}
	}

	public void EnableTextBox() 
	{
		textBox.SetActive (true);
		player.canMove = false;
		isActive = true;
	}

	public void DisableTextBox() 
	{
		textBox.SetActive (false);
		player.canMove = true;
		isActive = false;
	}

	public void ReloadScript(TextAsset theText) 
	{
		if (theText !=null) 
		{
			textLines = new string[1];
		}
	}

	public void loadConversation()
	{
		if (Character == null && Conversation == null) 
		{
			TextAsset BaseCamp = (TextAsset)AssetDatabase.LoadAssetAtPath ("Assets/Data/BaseCamp.txt", typeof(TextAsset));  
			textLines = (BaseCamp.text.Split ('\n')); 
		} else {
			myFile = "Assets/Data/Dialogue_";
			myFile += Character + "_"; 
			myFile += Conversation;
			myFile += ".txt";

			Debug.Log (myFile);

			TextAsset goodText = (TextAsset)AssetDatabase.LoadAssetAtPath (myFile, typeof(TextAsset));  
			textLines = (goodText.text.Split ('\n')); 
		}
		currentLine = 0;
		endAtLine = textLines.Length - 1;
	}
}
		