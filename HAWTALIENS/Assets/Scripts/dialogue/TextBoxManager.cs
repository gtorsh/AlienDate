using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.IO;
using System.Collections;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;
    public GameObject gChoice;
    public GameObject rChoice;
    public GameObject bChoice;
    public GameObject yChoice;

	public Text theText;
    public Text theActor;
    public Text greenChoice;
    public Text redChoice;
    public Text blueChoice;
    public Text yellowChoice;

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
    public bool firstPass;
    public int hasChoices = 0;
    public bool showChoices = false;

		// Use this for initialization
	void Start () 
	{
		player = FindObjectOfType<Movement> ();
        if (Conversation != 0)
        {
            Conversation = 0;
        }
	}


	// Update is called once per frame
	void Update () 
	{
        if (Global.playerState != Global.pState.TALK)
        {
            return;
        }
        switch (showChoices)
        {
            case false:
                if (firstPass)
                {
                    firstPass = false;
                    return;
                }
                if (Input.GetButtonDown("Green"))
                {
                    if (currentLine == endAtLine && !isWaiting && hasChoices == 0)
                    {
                        DisableTextBox();
                    }
                    else if (currentLine == endAtLine && !isWaiting && hasChoices != 0)
                    {
                        ShowChoices();
                    }
                    else if (!isWaiting)
                    {
                        ReloadScript();
                        currentLine += 1;
                        isWaiting = true;
                        updateText();
                    }
                    else if (isWaiting)
                    {
                        theText.text = tLine;
                        isWaiting = false;
                    }
                    if (tLine.Contains("<end>"))
                    {
                        DisableTextBox();
                    }
                }
                break;
            case true:
                if (Input.GetButtonDown("Green"))
                {
                    Conversation = Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].choices[0].dest;
                    DisableChoices();
                    loadConversation(Character);
                }
                else if (Input.GetButtonDown("Red"))
                {
                    if (!rChoice.activeSelf)
                    {
                        return;
                    }
                    Conversation = Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].choices[1].dest;
                    DisableChoices();
                    loadConversation(Character);
                }
                else if (Input.GetButtonDown("Blue"))
                {
                    if (!bChoice.activeSelf)
                    {
                        return;
                    }
                    Conversation = Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].choices[2].dest;
                    DisableChoices();
                    loadConversation(Character);
                }
                else if (Input.GetButtonDown("Yellow"))
                {
                    if (!yChoice.activeSelf)
                    {
                        Debug.Log("fired");
                        return;
                    }
                    Conversation = Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].choices[3].dest;
                    DisableChoices();
                    loadConversation(Character);
                }
                break;                
        }               
    }

	public void EnableTextBox() 
	{
		textBox.SetActive (true);
        firstPass = true;
        player.canMove = false;
		isActive = true;
        loadConversation(Character);
    }

	public void DisableTextBox() 
	{
        Global.playerState = Global.pState.WALK;
        textBox.SetActive (false);
		player.canMove = true;
		isActive = false;
        theText.text = "";
        theActor.text = "";
	}

    public void ShowChoices()
    {
        showChoices = true;
        switch (hasChoices)
        {
            case 1:
                greenChoice.text = "a: " + Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].choices[0].text;
                gChoice.SetActive(true);
                break;
            case 2:
                greenChoice.text = "a: " + Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].choices[0].text;
                redChoice.text = "b: " + Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].choices[1].text;
                gChoice.SetActive(true);
                rChoice.SetActive(true);
                break;
            case 3:
                greenChoice.text = "a: " + Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].choices[0].text;
                redChoice.text = "b: " + Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].choices[1].text;
                blueChoice.text = "x: " + Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].choices[2].text;
                gChoice.SetActive(true);
                rChoice.SetActive(true);
                bChoice.SetActive(true);
                break;
            case 4:
                greenChoice.text = "a: " + Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].choices[0].text;
                redChoice.text = "b: " + Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].choices[1].text;
                blueChoice.text = "x: " + Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].choices[2].text;
                yellowChoice.text = "y: " + Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].choices[3].text;
                gChoice.SetActive(true);
                rChoice.SetActive(true);
                bChoice.SetActive(true);
                yChoice.SetActive(true);
                break;
        }
    }

    public void DisableChoices()
    {
        showChoices = false;
        gChoice.SetActive(false);
        rChoice.SetActive(false);
        bChoice.SetActive(false);
        yChoice.SetActive(false);
    }

	public void ReloadScript() 
	{
		if (theText.text !=null) 
		{
            theText.text = null;
        }
	}
    public void updateText()
    {
        tLine = Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].textFrag[currentLine].text;
        theActor.text = Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].textFrag[currentLine].actor;
        StartCoroutine(TypeText());
    }

	public void loadConversation(string character)
	{
        if (Conversation == -1)
        {
            DisableChoices();
            DisableTextBox();
            return;
        }
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
        isWaiting = true;
        hasChoices = Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].choices.Count;
        ReloadScript();
        updateText();
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

		