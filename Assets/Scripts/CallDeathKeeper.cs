using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CallDeathKeeper : MonoBehaviour
{



    public DeathKeeperBehavior deathKeeperBehavior;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {

            deathKeeperBehavior.trackMonkey = true;
        }
    }
}
