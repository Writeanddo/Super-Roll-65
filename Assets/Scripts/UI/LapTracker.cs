using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTracker : MonoBehaviour
{
    public bool hitMidLap = false;
    public Text lapText;
    int lapCounter = 1;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && hitMidLap)
        {


            lapCounter++;
            hitMidLap = false;
            string lapCounterString = lapCounter.ToString();
            lapText.text = lapCounterString + "/3";

        }
    }

}
