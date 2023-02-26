using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FlashlightZoneBehavior : MonoBehaviour
{

    public Light spotlight;
    public GameObject lightTransparency;

    public Color standardColor;
   public Color flickerColor1;
    public Color flickerColor2;

    MysteryBoxManager mysteryBoxManager;

    bool triggered = false;


    // Start is called before the first frame update
    void Start()
    {
        mysteryBoxManager = GameObject.FindObjectOfType<MysteryBoxManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FlickerFlashlight()
    {
        triggered = true;
        StartCoroutine(FlickerRoutine());


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !triggered && mysteryBoxManager.flashlightOn)
        {

            FlickerFlashlight();

        }



    }


    IEnumerator FlickerRoutine()
    {
        //float clock = 0;

        yield return new WaitForSeconds(1f);
        spotlight.gameObject.SetActive(false);
        lightTransparency.SetActive(false);
        yield return new WaitForSeconds(.05f);
        spotlight.gameObject.SetActive(true);
        lightTransparency.SetActive(true);
        spotlight.color = flickerColor2;
        yield return new WaitForSeconds(.1f);
        spotlight.color = standardColor;

        yield return new WaitForSeconds(1.5f);

        spotlight.color = flickerColor1;
        yield return new WaitForSeconds(.2f);
        spotlight.gameObject.SetActive(false);
        lightTransparency.SetActive(false);
        yield return new WaitForSeconds(.1f);
        spotlight.color = standardColor;
        spotlight.gameObject.SetActive(true);
        lightTransparency.SetActive(true);
        yield return new WaitForSeconds(.3f);
        spotlight.color = flickerColor2;
        yield return new WaitForSeconds(.3f);
        spotlight.gameObject.SetActive(false);
        lightTransparency.SetActive(false);
        yield return new WaitForSeconds(.2f);
        spotlight.color = flickerColor1;
        spotlight.gameObject.SetActive(true);
        lightTransparency.SetActive(true);
        yield return new WaitForSeconds(.2f);
        spotlight.gameObject.SetActive(false);
        lightTransparency.SetActive(false);
        yield return new WaitForSeconds(.2f);
        spotlight.color = flickerColor2;
        spotlight.gameObject.SetActive(true);
        lightTransparency.SetActive(true);

        yield return new WaitForSeconds(.1f);
        spotlight.gameObject.SetActive(false);
        lightTransparency.SetActive(false);

        mysteryBoxManager.CloseItem();
        mysteryBoxManager.ChangeCurrentItemID(1);

    }
}
