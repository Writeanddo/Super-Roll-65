using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyNeedsSaving : MonoBehaviour
{

    public TimekeeperBehavior timekeeperBehavior;
    int monkeyCounter = 0;
    public int zone = 1;

    private void OnTriggerEnter(Collider other)
    {
        monkeyCounter++;
        if (zone == 1)
        {

            timekeeperBehavior.monkeyInZone1 = true;

            if (other.CompareTag("Player"))
            {
                timekeeperBehavior.playerInZone1 = true;
            }
        }

        if (zone == 2)
        {

            timekeeperBehavior.monkeyInZone2 = true;

            if (other.CompareTag("Player"))
            {
                timekeeperBehavior.playerInZone2 = true;
            }
        }

        if (zone == 3)
        {

            timekeeperBehavior.monkeyInZone3 = true;

            if (other.CompareTag("Player"))
            {
                timekeeperBehavior.playerInZone3 = true;
            }
        }





    }

    private void OnTriggerExit(Collider other)
    {
        monkeyCounter--;
        if (zone == 1)
        {
            if (other.CompareTag("Player"))
            {

                timekeeperBehavior.playerInZone1 = false;
            }

            if (monkeyCounter == 0)
            {

                timekeeperBehavior.monkeyInZone1 = false;

            }
        }

        if (zone == 2)
        {

            if (other.CompareTag("Player"))
            {

                timekeeperBehavior.playerInZone2 = false;
            }

            if (monkeyCounter == 0)
            {

                timekeeperBehavior.monkeyInZone2 = false;

            }
        }

        if (zone == 3)
        {

            if (other.CompareTag("Player"))
            {

                timekeeperBehavior.playerInZone3 = false;
            }

            if (monkeyCounter == 0)
            {

                timekeeperBehavior.monkeyInZone3 = false;

            }
        }





    }


}
