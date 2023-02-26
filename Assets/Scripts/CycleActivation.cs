using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleActivation : MonoBehaviour
{
    public GameObject[] objectsToCycle;
    public float cycleSpeed;
    float clock = 0;
    int currentCycle = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        clock += Time.deltaTime;
        
        if(clock > cycleSpeed )
        {
            for(int i = 0; i< objectsToCycle.Length; i++)
            {

                if(i == currentCycle)
                {

                    objectsToCycle[i].SetActive(true);
                }
                else
                {
                    objectsToCycle[i].SetActive(false);
                }

            }

            clock = 0;
            currentCycle += 1;
            if(currentCycle > objectsToCycle.Length - 1)
            {
                currentCycle = 0;
            }

        }
        
    }
}
