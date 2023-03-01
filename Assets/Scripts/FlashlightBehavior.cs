using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightBehavior : MonoBehaviour
{

    public GameObject[] gameObjectsToActivate;
    public FlashlightZoneBehavior flashlightZone;
    public Light spotlight;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        Debug.Log("enabled!");
        TellZoneToTimeUse();
        
        for(int i = 0;i<gameObjectsToActivate.Length;i++) {


            gameObjectsToActivate[i].SetActive(true);
        
        }
        spotlight.color = Color.white; 
    }



    void TellZoneToTimeUse()
    {
        flashlightZone.FlashLightStarted();


    }

}

