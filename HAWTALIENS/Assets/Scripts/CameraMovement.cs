using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameObject followTarget;
    public GameObject room;
    private SpriteRenderer spriteBounds;
    private Vector3 targetPos;
    private Vector3 modifiedPos;
	public float moveSpeed;
    public string roomName;

    public float vertExtent;
    public float horzExtent;

    private float targetX;
    private float targetY;

    public float minX;
    public float maxX;

    public float minY;
    public float maxY;

    public float padding;

    public bool cameraBounds;

    public int axisLocked;
    private int prevAxis;

    // Not Locked == -1
    //    Y Axis  ==  0
    //    X Axis  ==  1
    // X & Y Axis ==  2

    // Use this for initialization
    void Start () {
        prevAxis = axisLocked;
        padding = 0.5f;
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
        smoothCamera();
    }

    public void updatePos()
    {
        roomName = followTarget.gameObject.GetComponent<Movement>().roomName;
        room = GameObject.FindGameObjectWithTag(roomName);
        targetY = room.gameObject.transform.position.y;
        targetX = room.gameObject.transform.position.x;
        
        //calculates the size of the camera as well as the room and a
        spriteBounds = room.gameObject.GetComponent<SpriteRenderer>();
        print(gameObject.GetComponent<Camera>().orthographic);
        vertExtent = gameObject.GetComponent<Camera>().orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
        minX = (float)((spriteBounds.bounds.min.x + horzExtent) - padding);
        maxX = (float)((spriteBounds.bounds.max.x - horzExtent) + padding);
        minY = (float)((spriteBounds.bounds.min.y + vertExtent) - padding);
        maxY = (float)((spriteBounds.bounds.max.y - vertExtent) + padding);
    }

    void smoothCamera()
    {
        switch (axisLocked)
        {
            case (-1):
                targetPos = new Vector3(Mathf.Clamp(followTarget.transform.position.x, minX, maxX), Mathf.Clamp(followTarget.transform.position.y, minY, maxY), -50);
                transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
                break;
            case (0):
                targetPos = new Vector3(Mathf.Clamp(followTarget.transform.position.x, minX, maxX), targetY, -50);
                modifiedPos = new Vector3(transform.position.x, targetY, transform.position.z);
                transform.position = Vector3.Lerp(modifiedPos, targetPos, moveSpeed * Time.deltaTime);
                break;
            case (1):
                targetPos = new Vector3(targetX, Mathf.Clamp(followTarget.transform.position.y, minY, maxY), -50);
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
    }
}
