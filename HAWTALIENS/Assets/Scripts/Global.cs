using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

    public static DialogueContainer diaControl;

    // Use this for initialization
    void Start () {
        diaControl = DialogueContainer.Load("Assets/Data/Dialogue.xml");
        Debug.Log(diaControl.dContainers[0].dPack[0].entry[0].textFrag[0].text);
        Debug.Log(diaControl.dContainers[0].dPack[0].entry[0].textFrag[0].actor);
        Debug.Log(diaControl.dContainers[0].dPack[0].entry[0].textFrag[1].text);
        Debug.Log(diaControl.dContainers[0].dPack[0].entry[0].textFrag[1].actor);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
