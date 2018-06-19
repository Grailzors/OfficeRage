using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [Header("Stress Attributes")]
    public int workAmountIncrease = 5;
    public int increaseIntervals = 5;

    [Header("Clock Attributes")]
    public float startTime = 9f;
    public float lunchStart = 12f;
    public float lunchFinish = 13f;
    public float endTime = 17f;
    public float waitTime = 0f;

    static public float workLevel = 100f;
    static public float workReduceAmount = 0.5f;
    static public float colleagueAwarness = 0f;
    static public float clock;
    static public bool bossDetection;

    private float counter;
    //private GameObject screamZone;
    private float minutes;
    private float hours;
    
    private void Start()
    {
        SceneManager.LoadScene("MainUI", LoadSceneMode.Additive);

        //screamZone = GameObject.FindGameObjectWithTag("ScreamZone");
        counter = 0f;
        bossDetection = false;
        clock = startTime;
        hours = startTime;

        StartCoroutine(UpdateClock());

    }

    private void Update()
    {
        CountUp();
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

    private IEnumerator UpdateClock()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            minutes += 0.01f;

            if (minutes >= 0.59f)
            {
                hours += 1;
                minutes = 0f;
            }

            clock = hours + minutes;

            DayMileStones();
        }
    }

    void DayMileStones()
    {
        //Have some effect to show passage of time like screen fades to black
        //then fades back, maybe implent the week day in there aswell, don't
        //know how meaning full that is, might be funnier to not have it and
        //have this as a constant grind
        if(clock == lunchStart)
        {
            print("Lunch");
        }
        else if (clock == lunchFinish)
        {
            print("Lunch Over");
        }
        else if (clock == endTime)
        {
            print("End of the Day");
        }
    }
}
