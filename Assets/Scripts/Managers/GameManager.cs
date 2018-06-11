using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int workAmountIncrease = 5;
    public int increaseIntervals = 5;
    public float slowClock = 15f;

    static public float workLevel = 100f;
    static public float workReduceAmount = 0.5f;
    static public float colleagueAwarness = 0f;
    static public float clock;

    private float counter;
    private GameObject screamZone;
    
    private void Start()
    {
        SceneManager.LoadScene("MainUI", LoadSceneMode.Additive);

        screamZone = GameObject.FindGameObjectWithTag("ScreamZone");
        counter = 0f;
        clock = 9.00f;
    }

    private void Update()
    {
        CountUp();
        ClockCounter();
    }

    private void LateUpdate()
    {
        //ScreamZoneControler();
    }

    void CountUp()
    {
        if (counter < increaseIntervals)
        {
            counter += Time.deltaTime;
        }
        else if (counter >= increaseIntervals)
        {
            workLevel = workLevel + workAmountIncrease;
            counter = 0f;
        }
    }

    void ClockCounter()
    {
        //Progresses the time of day
        clock = clock + Time.deltaTime / slowClock; 
    }

    void EndofDay()
    {
        //Have some effect to show passage of time like screen fades to black
        //then fades back, maybe implent the week day in there aswell, don't
        //know how meaning full that is, might be funnier to not have it and
        //have this as a constant grind
        if (clock >= 5f)
        {
            print("End of the Day");
        }
    }

    /*
    void ScreamZoneControler()
    {
        //Currently setting the ScreamZone on and off 
        //Instead have it switch between two sprite for the room
        //Currently have this turned off not sure I want this, I feel 
        //it might not actual add much to the game play
        
        if (clock < 12.00f || clock > 9.10f)
        {
            screamZone.SetActive(false) ;
        }
        else
        {
            screamZone.SetActive(true);
        }
        
    }
    */
}
