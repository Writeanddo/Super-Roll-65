using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyDetector : MonoBehaviour
{
    int monkeyCounter = 0;
    public TimekeeperBehavior timekeeperBehavior;

    private void Update()
    {
        if(monkeyCounter > 0)
        {
            timekeeperBehavior.monkeyInRange = true;
        }
        else
        {
            timekeeperBehavior.monkeyInRange = false;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        monkeyCounter++;
    }

    private void OnTriggerExit(Collider other)
    {
        monkeyCounter--; 
    }
}
