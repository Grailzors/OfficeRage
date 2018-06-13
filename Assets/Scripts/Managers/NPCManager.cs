using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {

    public float awarnessAmount = 0f;

    private void LateUpdate()
    {
        print(GameManager.colleagueAwarness);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //print("Got Player");
            CheckPlayerScreaming();
        }
    }

    void CheckPlayerScreaming()
    {
        if (PlayerManager.isScreaming == true)
        {
            print("Player Is Screaming");
            GameManager.colleagueAwarness += Time.deltaTime;
        }
    }


}
