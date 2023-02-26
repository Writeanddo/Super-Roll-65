using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidlapTracker : MonoBehaviour
{

    public LapTracker lapTracker;



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            lapTracker.hitMidLap = true;
        }
    }
}
