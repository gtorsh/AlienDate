using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    private Animator anim;
    public bool doorOpened;
    public float timer;
    public Coroutine lastRoutine;
    public bool animTimer;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        timer = 3.0f;
        doorOpened = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Door_Close"))
        {
            print("The Door is opening");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Darrell")
        {
            if (timer > 0 && timer < 3 && doorOpened == true)
            {
                StopAllCoroutines();
                timer = 3.0f;
            } else
            {
                timer = 3;
                doorOpened = true;
                anim.Play("Door_Open");
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Darrell")
        {
            if (doorOpened == true)
            {
                timer = 3.0f;
                print("fired");
                lastRoutine = StartCoroutine(countDown());
            }
        }
    }

    IEnumerator countDown()
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        if (timer <= 0)
        {
            doorOpened = false;
            anim.Play("Door_Close");
        }
    }
}
