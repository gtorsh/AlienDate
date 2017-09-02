using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actualDoor : MonoBehaviour {

    public float xDest;
    public float yDest;
    public float zDest;
    private GameObject _camera;
    public Animator animator;
    public Image image;
    private GameObject Darrell;

    // Use this for initialization
    void Start () {
        _camera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Darrell")
        {
            Darrell = other.gameObject;
            StartCoroutine(fadeOut());
        }
    }

    IEnumerator fadeOut()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => image.color.a == 1);
        Darrell.gameObject.transform.position = new Vector3(xDest, yDest, zDest);
        _camera.gameObject.transform.position = new Vector3(xDest, yDest, -50);
        animator.SetBool("Fade", false);
    }
}
