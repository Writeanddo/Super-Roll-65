using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalTrigger : MonoBehaviour
{

    DeathKeeperBehavior[] deathKeepers;
    TowerBehavior towerBehavior;

    bool triggered = false;
    void Start()
    {
        towerBehavior = GameObject.FindFirstObjectByType<TowerBehavior>();  
        deathKeepers = GameObject.FindObjectsOfType<DeathKeeperBehavior>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !triggered)
        {

            towerBehavior.SetEndCamera();
            triggered = true;

            for(int i = 0;i < deathKeepers.Length;i++)
            {


                deathKeepers[i].poisonActive = false;
            }
            StartCoroutine(FinalSceneCountdown());
        }
    }


    IEnumerator FinalSceneCountdown()
    {

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);

        yield break;
    }

}
