using UnityEngine;
using UnityEngine.UI;
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

    private int arc;
	public int Conversation;
	public string Character;

	private string tLine;

	private int currentLine;
	private int endAtLine;
    private int tChar;
    public float letterPause = 0.1f;

	public Movement player;

	public bool isActive;

    private bool isWaiting = false;
    private bool firstPass;
    private int hasChoices = 0;
    private bool showChoices = false;

		// Use this for initialization
	void Start () 
	{
		player = FindObjectOfType<Movement> ();
        ///if (Conversation != 0)
        ///{
        ///    Conversation = 0;
        ///}
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
                if (Input.GetButtonDown(Global.green))
                {
                    if (currentLine == endAtLine && !isWaiting && hasChoices == 0)
                    {
                        if (Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].textFrag[currentLine].dest != 0)
                        {
                            Conversation = Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].textFrag[currentLine].dest;
                            loadConversation(Character);
                        }
                        else
                        {
                            DisableTextBox();
                        }
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
                if (Input.GetButtonDown(Global.green))
                {
                    Conversation = Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].choices[0].dest;
                    DisableChoices();
                    loadConversation(Character);
                }
                else if (Input.GetButtonDown(Global.red))
                {
                    if (!rChoice.activeSelf)
                    {
                        return;
                    }
                    Conversation = Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].choices[1].dest;
                    DisableChoices();
                    loadConversation(Character);
                }
                else if (Input.GetButtonDown(Global.blue))
                {
                    if (!bChoice.activeSelf)
                    {
                        return;
                    }
                    Conversation = Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].choices[2].dest;
                    DisableChoices();
                    loadConversation(Character);
                }
                else if (Input.GetButtonDown(Global.yellow))
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
        var chara = Character.ToUpper();
        tChar = enu.CHAR(chara);
        arc = Global.progControl.character[tChar].arc;
        Conversation = Global.progControl.character[tChar].conversation;
        textBox.SetActive (true);
        firstPass = true;
        player.canMove = false;
		isActive = true;
        loadConversation(Character);
    }

	public void DisableTextBox() 
	{
        if (Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].dest != 0)
        {
            Global.progControl.character[tChar].conversation = Global.diaControl.dContainers[tChar].dPack[arc].entry[Conversation].dest;
        } else
        {
            Global.progControl.character[tChar].conversation = Conversation;
        }
        print(Global.progControl.character[tChar].conversation);
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

		