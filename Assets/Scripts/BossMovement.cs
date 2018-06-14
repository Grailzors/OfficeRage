using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

    public float moveSpeed = 2f;

    private GameObject player;

    //Get the path system set up an then sort this stuff out
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        //This moves the boss to the player (chasing the player)
        //Current issue where the boss pushes the player needs to be fixed in the collider
        float step = moveSpeed * Time.deltaTime;
        Vector3 playerPos = player.transform.position;

        if (GameManager.bossDetection && PlayerManager.isWorking == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 0f, 0f), step);
            GameManager.bossDetection = false;
        }
    }
}
