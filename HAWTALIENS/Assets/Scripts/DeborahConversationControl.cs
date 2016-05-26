using UnityEngine;
using System.Collections;

public class DeborahConversationControl : MonoBehaviour {

	public int deborahProgress;

	public string dConvo;

	public TextBoxManager textimporter; 

	// Use this for initialization
	void Start () {
		textimporter = FindObjectOfType<TextBoxManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
