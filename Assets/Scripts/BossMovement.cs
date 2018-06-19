using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossMovement : MonoBehaviour {

    public int startPoint = 0;
    public float moveSpeed = 2f;
    public float waitTime = 5f;
    public Color viewColor = Color.red;
    public float viewHeight = 1.3f;
    public float viewDistance = 4f;

    private float step;
    private GameObject player;
    private int currentIndex;
    private bool directionState;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //Boss starts at what ever index is set in the inspector
        currentIndex = startPoint; 
        transform.position = PathManager.pathNodes[currentIndex].position;

        StartCoroutine(UpdateIndex());
    }

    private void Update()
    {
        step = moveSpeed * Time.deltaTime;

        BossMove();
        GetFacingDirection();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = viewColor;
        //Set the position of the box collider and its movement by adding the 
        //boss's position to the center value
        Gizmos.DrawCube(transform.position + gameObject.GetComponent<BoxCollider>().center, gameObject.GetComponent<BoxCollider>().size);
    }

    void BossMove()
    {
        //This moves the boss to the player (chasing the player)
        //Current issue where the boss pushes the player needs to be fixed in the collider
        Vector3 playerPos = player.transform.position;

        if (GameManager.bossDetection && PlayerManager.isWorking == false)
        {
            //Move towards player
            transform.position = Vector3.MoveTowards(transform.position, playerPos, step);
        }
        else
        {
            //Follow the path 
            GameManager.bossDetection = false;
            transform.position = Vector3.MoveTowards(transform.position, PathManager.pathNodes[currentIndex].position, step);
        }
    }
    
    void GetFacingDirection()
    {
        //Function to detect what direction the boss is facing
        Vector3 target;

        //Set what the target is the boss is moving towards
        if (GameManager.bossDetection == true)
        {
            target = player.transform.position;
        }
        else
        {
            target = PathManager.pathNodes[currentIndex].position;
        }

        //Calculate the direction the boss is moving
        Vector3 direction = transform.position - target;
        Vector3 facingDirection = transform.InverseTransformDirection(direction);
        
        //Using the facingDirection normalized to get a value between -1 to 1 
        gameObject.GetComponent<BoxCollider>().center = new Vector3(facingDirection.normalized.x * -1, 0f, 0f);

    }

    private IEnumerator UpdateIndex()
    {
        //Here I am updating the index every 'X' seconds and having it ping pong 
        //through the list of transforms from the PathManager
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            //int prev = currentIndex - 1;
            //int next = currentIndex + 1;

            //print(string.Format("Prev: {0}", prev));
            //print(string.Format("Next: {0}", next));

            //This chooses what direction through the list the boss moves through
            if (currentIndex == PathManager.pathNodes.Count - 1)
            {
                directionState = false;
            }
            else if (currentIndex == 0)
            {
                directionState = true;
            }

            //This Changes the actual index number while cycling through the list
            if (directionState == true)
            {
                currentIndex += 1;
            }
            else if (directionState == false)
            {
                currentIndex -= 1;
            }
        }
    }
}