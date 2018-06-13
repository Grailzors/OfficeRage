using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private string working = "Press Space Bar to stop working";
    private string notWorking = "Press Space Bar to work";

    private void LateUpdate()
    {
        WorkingTextUI();
        StressMeter();
        WorkMeter();
        ClockUpdate();
        AwarnessUpdate();
    }

    void WorkingTextUI()
    {
        if (PlayerManager.isWorking == true)
        {
            gameObject.transform.GetChild(4).GetComponent<Text>().text = working;
        }
        else
        {
            gameObject.transform.GetChild(4).GetComponent<Text>().text = notWorking;
        }
    }

    void StressMeter()
    {
        gameObject.transform.GetChild(0).GetComponent<Slider>().value = PlayerManager.stressLevel;
    }

    void WorkMeter()
    {
        gameObject.transform.GetChild(2).GetComponent<Slider>().value = GameManager.workLevel;
    }

    void ClockUpdate()
    {
        gameObject.transform.GetChild(5).GetComponent<Text>().text = string.Format("{0:N2}", GameManager.clock);
    }

    void AwarnessUpdate()
    {
        gameObject.transform.GetChild(6).GetComponent<Slider>().value = GameManager.colleagueAwarness;
    }
}
