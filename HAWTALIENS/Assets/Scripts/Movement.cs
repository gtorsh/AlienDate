﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float movespeed;

	private Animator anim;
	private Rigidbody2D myRigidbody;

	private bool playerMoving;
	public Vector2 lastMove;
	public bool canMove;

    private Global.pState tpState;

    public GameObject pMenu;


	void Start () {
		anim = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody2D> ();
		playerMoving = true;
	}

	void Update () {
        switch (Global.playerState)
        {
            case (Global.pState.WALK):
                ///-------------------------------------Gets Inputs-------------------------------------///
                if (Input.GetButtonDown(Global.start))
                {
                    pause();
                }
                ///--------------------------------------Handles Movement-------------------------------///
                if (canMove == false)
                {
                    movespeed = 0;
                }
                else
                {
                    movespeed = 8;
                }

                if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
                {
                    playerMoving = true;
                    lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                    myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movespeed, myRigidbody.velocity.y);
                }
                if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
                {
                    playerMoving = true;
                    lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * movespeed);
                }

                if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5)
                {
                    myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
                }

                if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5)
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
                }

                anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
                anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
                anim.SetBool("PlayerMoving", playerMoving);
                anim.SetFloat("LastMoveX", lastMove.x);
                anim.SetFloat("LastMoveY", lastMove.y);
                break;
            case (Global.pState.TALK):
                if (Input.GetButtonDown(Global.start))
                {
                    pause();
                }
                break;
            case (Global.pState.PAUSED):
                if (Input.GetButtonDown(Global.start))
                {
                    Time.timeScale = 1;
                    pMenu.SetActive(false);
                    canMove = true;
                    Global.playerState = tpState;
                } else if (Input.GetButtonDown(Global.green))
                {
                    print("You Saved!!!");
                    Global.progControl.Save();
                }
                else if (Input.GetButtonDown(Global.red))
                {
                    print("You Loaded!!!");
                    Global.progControl = progControl.Load("Assets/Data/baseSaveFile.xml");
                }
                break;
        }
        playerMoving = false;
	}

    void pause()
    {
        Time.timeScale = 0;
        pMenu.SetActive(true);
        canMove = false;
        tpState = Global.playerState;
        Global.playerState = Global.pState.PAUSED;
        print(tpState);
        print(Global.playerState);
    }
}
