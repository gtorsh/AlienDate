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

	public int currentLine;
	public int endAtLine;

	public Movement player;

		// Use this for initialization
	void Start () {
		currentLine = 0;
		player = FindObjectOfType<Movement> ();

		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}

		if (Character == null && Conversation == null) {
			TextAsset BaseCamp = (TextAsset)AssetDatabase.LoadAssetAtPath("Assets/Data/BaseCamp.txt", typeof(TextAsset));  
			textLines = (BaseCamp.text.Split ('\n')); 

			string myFile = Character; 
			myFile += Conversation;
			myFile += ".txt";
			Debug.Log (myFile);
		} 
		
	}


	// Update is called once per frame
	void Update () {

			theText.text = textLines[currentLine];

			if(Input.GetKeyDown(KeyCode.Return)) {
				currentLine += 1;
			}

			if (currentLine > endAtLine) {
				textBox.SetActive(false);
			}
	}

}
		