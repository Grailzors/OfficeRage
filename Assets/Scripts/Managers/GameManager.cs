using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int workAmountIncrease = 5;
    public int increaseIntervals = 5;
    public float slowClock = 15f;

    public float waitTime = 0f;

    static public float workLevel = 100f;
    static public float workReduceAmount = 0.5f;
    static public float colleagueAwarness = 0f;
    static public float clock;
    static public bool bossDetection;

    private float counter;
    private GameObject screamZone;
    private float minutes;
    
    private void Start()
    {
        SceneManager.LoadScene("MainUI", LoadSceneMode.Additive);

        screamZone = GameObject.FindGameObjectWithTag("ScreamZone");
        counter = 0f;
        clock = 9.00f;
        bossDetection = false;
        minutes = 0f;

        StartCoroutine(UpdateClock());

    }

    private void Update()
    {
        CountUp();
        //ClockCounter();
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

    //void ClockCounter()
    //{
    //    //Progresses the time of day
    //    clock = clock + Time.deltaTime / slowClock; 
    //}


    private IEnumerator UpdateClock()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            
            minutes += 0.01f;
            print(minutes);

            if (minutes == 0.60f)
            {
                minutes = 0f;
            }



            //clock += minutes;
        }
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
}
