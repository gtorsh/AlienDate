using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actualDoor : MonoBehaviour {

    public GameObject doorLink;
    private GameObject Darrell;
    private GameObject _camera;
    private door otherDoor;

    public Animator animator;
    public Image image;

    public float xDest;
    public float yDest;
    public float zDest;

    // Use this for initialization
    void Start () {
        _camera = GameObject.Find("Main Camera");
        xDest = doorLink.transform.position.x;
        yDest = doorLink.transform.position.y - 0.2f;
        zDest = -5;
        otherDoor = doorLink.GetComponent<door>();
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
        otherDoor.timer = 3.0f;
        otherDoor.animOpen = false;
        otherDoor.anim.SetBool("opened", otherDoor.animOpen);
        otherDoor.anim.speed = 10;
        yield return new WaitUntil(() => image.color.a == 1);
        Darrell.gameObject.transform.position = new Vector3(xDest, yDest, zDest);
        _camera.gameObject.transform.position = new Vector3(xDest, yDest, -50);
        animator.SetBool("Fade", false);
        otherDoor.anim.speed = 1;
    }
}
