using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour {

    [Header("Boss Attributes")]
    public float addInitialStressAmount = 20f;
    public float addStressAmount = 0f;

    [Header("Gizmo Attributes")]
    public Color viewColor = Color.red;
    public float viewHeight = 1.3f;
    public float viewDistance = 4f;

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
            PlayerManager.stressLevel += addInitialStressAmount;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = viewColor;
        //Set the position of the box collider and its movement by adding the 
        //boss's position to the center value
        Gizmos.DrawCube(transform.position + gameObject.GetComponent<BoxCollider>().center, gameObject.GetComponent<BoxCollider>().size);
    }

}
