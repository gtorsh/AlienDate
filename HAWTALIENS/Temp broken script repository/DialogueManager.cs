using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour {

	public string dialogue, characterName;
	public int lineNum;
	int pose;
	string position;
	string[] options;
	public bool playerTalking;
	List<Button> buttons = new List<Button> ();

	public Text dialogueBox;
	public Text nameBox;
	public GameObject choiceBox;

	// Use this for initialization
	void Start () {
		dialogue = "";
		characterName = "";
		pose = 0;
		position = "L";
		playerTalking = false;
		parser = GameObject.Fine ("DialogueParser").GetComponent<DialogueParser> ();
		lineNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && playerTalking == false) {
			Showdialogue ();

			lineNum++;
		}

		UpdateUI ();	
	}

	public void ShowDialogue() {
		ResetImages ();
		ParseLine ();
	}

	void ResetImages() {
		if (characterName != "") {
			GameObject character = GameObject.Find (characterName);
			SpriteRenderer currSprite = character.GetComponent<SpriteRenderer> ();
			currSprite.sprite = null;
		}
	}

	void ParseLine() {
		if (ParseLine.GetName (lineNum) != "Player") {
			playerTalking = false;
			characterName = ParseLine.GetName (lineNum);
			dialogue = ParseLine.GetContent (lineNum);
			pose = parser.GetPose (lineNum);
			position = parser.GetPosition (lineNum);
			DisplayImages ();
		} else {
			playerTalking = true;
			chacterName = "";
			dialogue = "";
			pose = 0;
			position = "";
			options = DialogueParser.GetOptions (lineNum);
			CreateButtons ();
		}
	}

	void DisplayImages() {
		if (characterName != "") {
			GameObject character = GameObject.Find (characterName);

			SetSpritePositions (character);

			SpriteRenderer currSprite = character.GetComponent<SpriteRenderer> ();
			currSprite.sprite = character.GetComponent<character> ().characterPoses [pose];
		}
	}

	void SetSpritePositions(GameObject spriteObj) {
		if (position == "L") {
			spriteObj.transform.position = new Vector3 (-6, 0);
		} else if (position == "R") {
			spriteObj.transform.position = new Vector3 (6, 0);
		}
		spriteObj.transform.position = new Vector3 (spriteObj.transform.position.x, spriteObj.transform.position.y, 0);
	}


}
