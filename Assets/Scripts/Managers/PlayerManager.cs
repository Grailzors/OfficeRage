using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public float stressLevelSpeed = 0.5f;
    
    static public float stressLevel = 0f;
    static public bool isWorking;
    static public bool isScreaming;

    private float num;
    private bool workArea;
    private Dictionary<string, float> screamEntities; 

    private void Start()
    {
        workArea = false;
        isWorking = false;
        isScreaming = false;

        ScreamableEntities();
    }

    private void Update()
    {
        PlayerWorking();
    }

    private void OnTriggerEnter(Collider other)
    {
        //just for debuging now can be deleted later
        if (other.tag == "ScreamZone")
        {
            print("Scream Now!!!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "StressZone")
        {
            StressPlayer();
        }

        if (other.tag == "ScreamZone")
        {
            DestressPlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "StressZone")
        {
            stressLevelSpeed = 1;
            workArea = false;
        }
    }

    void StressPlayer()
    {
        if (isWorking && Input.GetKeyDown(KeyCode.Space) == true)
        {
            isWorking = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            isWorking = true;
            workArea = true;
        }

        if (isWorking && workArea == true)
        {
            //Here the stress level increases getting faster the longer they are working
            stressLevel += (1f * Time.deltaTime) * stressLevelSpeed;
            stressLevelSpeed += StressLevelSpeedControl();
        }
    }

    void DestressPlayer()
    {
        if (Input.GetKey(KeyCode.E))
        {
            print("AAAAAAAAAAAAAHHHHHHHHHHHHHHHHHHHH");
            stressLevel -= (1.8f * Time.deltaTime);
            isScreaming = true;
        }
        else
        {
            isScreaming = false;
        }
    }

    private float StressLevelSpeedControl()
    {
        //This controls the thresholds that increase the speed of the stress level
        if (stressLevel < 20)
        {
            num = 0.5f ;
            //print("Level 1");
        }
        else if (stressLevel < 50)
        {
            num = 1;
            //print("Level 2");
        }
        else if (stressLevel < 70)
        {
            num = 3;
            //print("Level 3");
        }
        else if (stressLevel > 90)
        {
            num = 0.01f;
            //print("Level 4");
        }
        return num * Time.deltaTime;
    }

    void PlayerWorking()
    {
        if (workArea == true)
        {
            if (Input.anyKeyDown)
            {
                GameManager.workLevel -= GameManager.workReduceAmount;
            }
        }
    }

    void ScreamAt(string entity, Collider other)
    {
        if (other.tag == "Screamable")
        {
            stressLevel -= ScreamableEntities()[entity];
        }
    }

    Dictionary<string, float> ScreamableEntities()
    {
        screamEntities = new Dictionary<string, float>();

        screamEntities.Add("Sleave", 5f);
        screamEntities.Add("Cup", 8f);
        screamEntities.Add("Plant", 10f);
        screamEntities.Add("Birds", 10f);
        screamEntities.Add("Window", 15f);

        return screamEntities;
    }
}
