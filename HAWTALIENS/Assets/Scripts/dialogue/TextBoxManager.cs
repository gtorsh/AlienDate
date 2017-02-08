using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.IO;
using System.Collections;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;

	public Text theText;
    public Text theActor;

    public int arc;
	public int Conversation;
	public string Character;

	public string tLine;

	public int currentLine;
	public int endAtLine;
    public int tChar;
    public float letterPause = 0.1f;

	public Movement player;

	public bool isActive;

    public bool isWaiting = false;

		// Use this for initialization
	void Start () 
	{
		player = FindObjectOfType<Movement> ();
	}


	// Update is called once per frame
	void Update () 
	{
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("You pressed Space");
            if (currentLine == endAtLine && !isWaiting)
            {
                DisableTextBox();                   
            } else if (!isWaiting) {
                ReloadScript();
                currentLine += 1;
                updateText();
                isWaiting = true;
                StartCoroutine(TypeText());
            } else if (isWaiting) {
                theText.text = tLine;
                isWaiting = false;
            }
            if (tLine.Contains("<end>"))
            {
                DisableTextBox();
            }
		}
        if (currentLine <= endAtLine)
        {
            updateText();
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

	public void ReloadScript() 
	{
		if (theText.text !=null) 
		{
            theText.text = "";
            updateText();
        }
	}
    public void updateText()
    {
        tLine = Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].textFrag[currentLine].text;
        theActor.text = Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].textFrag[currentLine].actor;
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
        endAtLine = Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].textFrag.Count - 1;
        currentLine = 0;
        ReloadScript();
        isWaiting = true;
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        while (isWaiting)
        {
            foreach (char letter in tLine.ToCharArray())
            {
                if (theText.text == tLine)
                {
                    isWaiting = false;
                    yield break;
                }
                if (!isWaiting)
                {
                    yield break;
                }
                theText.text += letter;
                //if (typeSound1 && typeSound2)
                //    SoundManager.instance.RandomizeSfx(typeSound1, typeSound2);
                yield return 0;
                yield return new WaitForSeconds(letterPause);
            }
        }
    }
}

		