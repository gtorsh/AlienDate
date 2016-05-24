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

		// Use this for initialization
	void Start () {
		currentLine = 0;
		player = FindObjectOfType<Movement> ();

		if (Character == null && Conversation == null) {
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
		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}
	}


	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space)) {
			currentLine += 1;
		}

		if (currentLine <= endAtLine) {
			theText.text = textLines [currentLine];
		} else {
			textBox.SetActive(false);
			theText.text = null;
		}
	}

}
		