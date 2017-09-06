using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    public Animator anim;
    private Coroutine lastRoutine;
    public GameObject otherDoor;

    public bool doorOpened;
    private bool animTimer;
    public bool animOpen;
    public bool isLocked;
    public string key; // first put type ("Item","Flag") + "|" + name of flag or item (i.e. "Item|Visitor Pass"
    private string[] keys;
    private bool hasKey;

    public float timer;
    public bool inTrigger;

    public string room;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        timer = 3.0f;
        doorOpened = false;
        animOpen = anim.GetBool("opened");
        inTrigger = false;
        otherDoor = gameObject.GetComponentInChildren<actualDoor>().doorLink;
        if (key != null || key != "")
        {
            doorUpdate(true, key);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (inTrigger && hasKey && Input.GetButtonDown(Global.green))
        {
            isLocked = false;
            StartCoroutine(waitForAnimation());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Darrell")
        {
            if (inTrigger) return;
            inTrigger = true;
            if (isLocked == true)
            {
                if (key != null || key != "")                                                                       //Checks if anything is there
                {
                    switch (keys[0])                                                                                //Checks the type of key
                    {
                        case "Item":                                                                                //Case Item
                            Inventory global = GameObject.Find("Global").GetComponent<Inventory>();
                            if (global.CheckInventory(keys[1]))                                                     //Checks if the item is in the inventory
                            {
                                gameObject.GetComponent<Interact>().enabled = false;
                                hasKey = true;
                            } else
                            {
                                gameObject.GetComponent<Interact>().enabled = true;
                            }
                            break;
                        default:
                            gameObject.GetComponent<Interact>().enabled = true;
                            break;
                    }
                    
                }
                return;
            }
            else
            {
                if (timer > 0 && timer < 3 && animOpen == false)
                {
                    StopAllCoroutines();
                    timer = 3.0f;
                }
                else
                {
                    StartCoroutine(waitForAnimation());
                }
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Darrell")
        {
            if (inTrigger == false) return;
            inTrigger = false;
            if (isLocked == true)
            {
                gameObject.GetComponent<Interact>().enabled = true;
                return;
            }
            else
            {
                if (otherDoor.GetComponent<door>().inTrigger == false)
                {
                    if (animOpen == false)
                    {
                        timer = 3.0f;
                        lastRoutine = StartCoroutine(countDown());
                    }
                }
            }
        }
    }

    public void doorUpdate(bool Lock_Door, string key)
    {
        isLocked = Lock_Door;
        keys = key.Split('|');
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

    public IEnumerator waitForAnimation()
    {
        if (animOpen == false)
        {
            yield break;
        }
        do
        {
            yield return null;
        } while (doorOpened == true);
        timer = 3;
        animOpen = false;
        anim.SetBool("opened", animOpen);
    }
}
