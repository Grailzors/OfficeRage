using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed = 0;

    private int x;
    private int y;

	// Update is called once per frame
	void Update ()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        y = Convert.ToInt32(Input.GetKey(KeyCode.W)) + (Convert.ToInt32(Input.GetKey(KeyCode.S)) * -1);
        x = (Convert.ToInt32(Input.GetKey(KeyCode.A )) * -1) + Convert.ToInt32(Input.GetKey(KeyCode.D));

        if (PlayerManager.isWorking == false)
        {
            transform.position = transform.position + new Vector3((x * Time.deltaTime) * playerSpeed, (y * Time.deltaTime) * playerSpeed, 0);
        } 
    }

}
