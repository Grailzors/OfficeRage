using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour {

    public float addStressAmount = 0f;

    //Make sure that the boss hasa field of view so the player has
    //to avoid the boss
    //if boss finds the player, have the boss chase the player back
    //to their desk, this should also increase the player stressLevel

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("CAUGHT PLAYER!!");
            GameManager.bossDetection = true;
            PlayerManager.stressLevel += 20f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            print("GET BACK TO YOUR DESK!!");
            GameManager.bossDetection = true;
            PlayerManager.stressLevel += addStressAmount * Time.deltaTime;
        }
    }

}
