using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

    public static DialogueContainer diaControl;

    // Use this for initialization
    void Start () {
        diaControl = DialogueContainer.Load("Assets/Data/Dialogue.xml");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
