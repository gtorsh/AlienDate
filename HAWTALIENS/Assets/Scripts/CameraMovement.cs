using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameObject followTarget;
    private GameObject room;
	private Vector3 targetPos;
    private Vector3 modifiedPos;
	public float moveSpeed;
    public string roomName;

    private float targetX;
    private float targetY;

    public int axisLocked;
    private int prevAxis;

    // Not Locked == -1
    //    Y Axis  ==  0
    //    X Axis  ==  1
    // X & Y Axis ==  2

	// Use this for initialization
	void Start () {
        prevAxis = axisLocked;
        updatePos();
    }
	
	// Update is called once per frame
	void Update () {
        if (axisLocked != prevAxis)
        {
            if (axisLocked != -1)
            {
                updatePos();
            }
            prevAxis = axisLocked;
        }
        switch (axisLocked)
        {
            case (-1):
                targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, -50);
                transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
                break;
            case (0):
                targetPos = new Vector3(followTarget.transform.position.x, targetY, -50);
                modifiedPos = new Vector3(transform.position.x, targetY, transform.position.z);
                transform.position = Vector3.Lerp(modifiedPos, targetPos, moveSpeed * Time.deltaTime);
                break;
            case (1):
                targetPos = new Vector3(targetX, followTarget.transform.position.y, -50);
                modifiedPos = new Vector3(targetX, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(modifiedPos, targetPos, moveSpeed * Time.deltaTime);
                break;
            case (2):
                targetPos = new Vector3(targetX, targetY, -50);
                modifiedPos = new Vector3(targetX, targetY, transform.position.z);
                transform.position = Vector3.Lerp(modifiedPos, targetPos, moveSpeed * Time.deltaTime);
                break;
            default:
                targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, -50);
                transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
                break;
        }
        roomName = followTarget.gameObject.GetComponent<Movement>().roomName;
    }

    public void updatePos()
    {
        room = GameObject.FindGameObjectWithTag(roomName);
        targetY = room.gameObject.transform.position.y;
        targetX = room.gameObject.transform.position.x;
    }
}
