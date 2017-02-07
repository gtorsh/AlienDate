using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.IO;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;

	public Text theText;
    public Text theActor;

	public int Conversation;
	public string Character;
	public string textLine;

	public int currentLine;
	public int endAtLine;
    private int tChar;

	public Movement player;

	public bool isActive;

		// Use this for initialization
	void Start () 
	{
		player = FindObjectOfType<Movement> ();
	}


	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("You pressed Space");
            if (currentLine == endAtLine)
            {
                DisableTextBox();                   
            } else {
                currentLine += 1;
            }
            if (textLine.Contains("<end>"))
            {
                DisableTextBox();
            }

		}
        if (currentLine <= endAtLine) 
		{
            theText.text = Global.diaControl.dContainers[tChar].dPack[Conversation].entry[currentLine].dText;
            theActor.text = Global.diaControl.dContainers[tChar].dPack[Conversation].entry[currentLine].actor;
        } 
    }

	public void EnableTextBox() 
	{
		textBox.SetActive (true);
		player.canMove = false;
		isActive = true;
        loadConversation(Character, Conversation);
    }

	public void DisableTextBox() 
	{
		textBox.SetActive (false);
		player.canMove = true;
		isActive = false;
        theText.text = "";
        theActor.text = "";
	}

	public void ReloadScript(TextAsset theText) 
	{
		if (theText !=null) 
		{
            textLine = "";
        }
	}

	public void loadConversation(string character,int conversation)
	{
        var chara = character.ToUpper();
        tChar = -1;
        switch (chara)
        {
            case "DEBORAH":
                tChar = 0;
                break;
            case "ORBOS":
                tChar = 1;
                break;
            default:
                break;
        }
        Debug.Log(character);
        Debug.Log(chara);
        Debug.Log(tChar);
        Debug.Log(conversation);
        endAtLine = Global.diaControl.dContainers[tChar].dPack[conversation].entry.Count - 1;
        currentLine = 0;
        Debug.Log(endAtLine);  
    }
}

		