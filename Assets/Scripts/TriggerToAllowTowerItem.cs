using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToAllowTowerItem : MonoBehaviour
{

    int playerCount = 0;
    MysteryBoxManager m_BoxManager;
    // Start is called before the first frame update
    void Start()
    {
        m_BoxManager = GameObject.FindObjectOfType<MysteryBoxManager>();    
    }




    private void OnTriggerEnter(Collider other)
    {
        


        if(other.CompareTag("Player"))
        {

            playerCount++;
            m_BoxManager.ChangeCurrentItemID(2); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {


            playerCount--;

            if(playerCount <= 0)
            {


                m_BoxManager.ChangeCurrentItemID(1);
            }
        }
    }

}
