using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using Photon.Pun;

public class Car_Movement : MonoBehaviour
{
    public PathCreator pathCreator;
    public GameObject[] nodes;
    public GameObject finishedNode;
    public int currNode;
    public int nextNodeNum;

    public GameObject currNodeObj;
    public GameObject nextNodeObj;

    public bool freeplay;
    public static bool multiplayer;

    public float distanceTravelled;

    public SpriteRenderer spriteSkin;

    public int finishedCount;

    public PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        // Set whether in multiplayer mode or not.
        multiplayer = GameManager.privateMultiplayer;
        currNode = -1;
        nextNodeNum = 0;
        currNodeObj = nodes[3];
        nextNodeObj = nodes[0];
        if (multiplayer) {
            view = GetComponent<PhotonView>();
            if (view.IsMine)
            {
                spriteSkin.color = ColorManager.GetCarColor();
            }
        }
        else
        {
            spriteSkin.color = ColorManager.GetCarColor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (multiplayer) {
            if (view.IsMine)
            {
                CheckInput();
            }
        }
        else
        {
            CheckInput();
        }
    }

    private void CheckInput()
    {
        // Check which mode the player is in.
        if (!freeplay)
        {
            if (!multiplayer)
            {
                TimeLimitMovement();
            }
            else
            {
                HowFastMovement();
            }
        }
        else
        {
            if (!ButtonManager_TimeLimit.done)
            {
                distanceTravelled += ButtonManager_FreePlay.velocity * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
                LookAt.node = nextNodeObj.transform;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Set the next node the car will "look" towards.
        if (collision.gameObject.tag == "Node")
        {
            nextNodeObj = nodes[1];
        }
        else if (collision.gameObject.tag == "Node1")
        {
            nextNodeObj = nodes[2];
        }
        else if (collision.gameObject.tag == "Node2")
        {
            nextNodeObj = nodes[3];
        }
        else if (collision.gameObject.tag == "Node3")
        {
            nextNodeObj = nodes[0];
        }

        /* Since other player's copy of nodes are also present,
        check if the player is colliding with a similar node already so that it doesn't get counted twice. */
        if (!currNodeObj.tag.Equals(collision.gameObject.tag))
        {
            currNode = nextNodeNum;
            nextNodeNum++;
            currNodeObj = collision.gameObject;
        }

    }

    private void TimeLimitMovement()
    {
        if (!ButtonManager_TimeLimit.finished)
        {
            distanceTravelled += ButtonManager_TimeLimit.velocity * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            if (currNode <= nodes.Length * ButtonManager_TimeLimit.laps - 1)
            {
                LookAt.node = nextNodeObj.transform;
            }
        }
        else
        {
            // Makes the car look straight if last node was collided with.
            if (currNode >= nodes.Length * ButtonManager_TimeLimit.laps - 1)
            {
                LookAt.node = finishedNode.transform;
            }
        }

        if (currNode == nodes.Length * ButtonManager_TimeLimit.laps)
        {
            ButtonManager_TimeLimit.finished = true;
        }
    }

    private void HowFastMovement()
    {
        if (!ButtonManager_HowFast.finished)
        {
            distanceTravelled += ButtonManager_HowFast.velocity * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            if (currNode <= nodes.Length * ButtonManager_HowFast.laps - 1)
                LookAt.node = nextNodeObj.transform;
        }
        else
        {
            // Makes the car look straight if last node was collided with.
            if (currNode >= nodes.Length * ButtonManager_HowFast.laps - 1)
            {
                LookAt.node = finishedNode.transform;
            }
        }

        if (currNode >= nodes.Length * ButtonManager_HowFast.laps)
        {
            ButtonManager_HowFast.finished = true;
            finishedCount++;
        }

        if (finishedCount == PhotonNetwork.PlayerList.Length)
        {
            Debug.Log("All Cars Finished");
        }
    }
}
