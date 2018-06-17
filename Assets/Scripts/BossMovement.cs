using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossMovement : MonoBehaviour {

    public float moveSpeed = 2f;

    private GameObject player;
    private int currentIndex;


    //Get the path system set up an then sort this stuff out
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //Choose Bosses starting point randomly
        currentIndex = Random.Range(0, PathManager.pathNodes.Count);
        transform.position = PathManager.pathNodes[currentIndex].position;
    }

    private void Update()
    {
        //FollowPlayer();
        BossMove();
    }

    void FollowPlayer()
    {
        //This moves the boss to the player (chasing the player)
        //Current issue where the boss pushes the player needs to be fixed in the collider
        float step = moveSpeed * Time.deltaTime;
        Vector3 playerPos = player.transform.position;
        Vector3 bossPos;

        if (GameManager.bossDetection && PlayerManager.isWorking == false)
        {
            bossPos = transform.position;
            transform.position = Vector3.MoveTowards(transform.position, playerPos, step);
        }
        else
        {
            GameManager.bossDetection = false;
        }
    }

    //Have this function control the movement of the boss around the environment
    private IEnumerator BossMove()
    {
        float step = moveSpeed * Time.deltaTime;
 

        transform.position = Vector3.MoveTowards(transform.position, PathManager.pathNodes[currentIndex + 1].position, step);





    }
}
