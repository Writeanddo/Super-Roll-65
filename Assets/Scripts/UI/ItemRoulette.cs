using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemRoulette : MonoBehaviour
{
    public GameObject[] itemList;
    public bool rouletteOn = false;
    float clock = 0;
    public int currentSelection = 0;
    public float spinSpeed = .25f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rouletteOn)
        {
            clock += Time.deltaTime;

            if (clock > spinSpeed)
            {
                SpinRoulette();
                clock = 0;
            }
        }
    }

    void SpinRoulette()
    {
        for(int i = 0;i< itemList.Length;i++) { 
        

            if(i == currentSelection)
            {

                itemList[i].SetActive(true);
            }
            else
            {
                itemList[i].SetActive(false);

            }
        
        }

        currentSelection += 1;

        if(currentSelection > itemList.Length - 1)
        {

            currentSelection = 0;
        }



    }

    public void StopRoulette()
    {

        rouletteOn = false;
        for (int i = 0; i < itemList.Length; i++)
        {


                itemList[i].SetActive(false);

        }

    }

}
