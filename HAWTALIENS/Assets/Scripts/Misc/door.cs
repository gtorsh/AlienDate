using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    public Animator anim;
    private Coroutine lastRoutine;

    public bool doorOpened;
    private bool animTimer;
    public bool animOpen;

    public float timer;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        timer = 3.0f;
        doorOpened = false;
        animOpen = anim.GetBool("opened");
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
            if (timer > 0 && timer < 3 && animOpen == false)
            {
                StopAllCoroutines();
                timer = 3.0f;
            } else
            {
                StartCoroutine(waitForAnimation());
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Darrell")
        {
            if (animOpen == false)
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
            animOpen = true;
            anim.SetBool("opened", animOpen);
            //anim.Play("Door_Close");
        }
    }

    IEnumerator waitForAnimation()
    {
        do
        {
            yield return null;
        } while (doorOpened == true);
        timer = 3;
        animOpen = false;
        anim.SetBool("opened", animOpen);
    }
}
