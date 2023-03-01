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

    public GameObject starOutline;

    MysteryBoxManager mysteryBoxManager;

    public bool triggered = false;
    bool flashlightOn = false;
    float maxFlashlightDuration = 30;
    float flashlightClock = 0;

    // Start is called before the first frame update
    void Start()
    {
        mysteryBoxManager = GameObject.FindObjectOfType<MysteryBoxManager>();
        starOutline.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(flashlightOn)
        {
            CountdownFlashlight();
        }

        if(flashlightClock >= 30 && flashlightOn)
        {
            flashlightOn = false;
            StartCoroutine(ShortFlicker());

        }
    }

    void FlickerFlashlight()
    {
        triggered = true;
        StartCoroutine(FlickerRoutine());


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !triggered && mysteryBoxManager.flashlightOn && flashlightOn)
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
        yield return new WaitForSeconds(.1f);
        spotlight.gameObject.SetActive(true);
        lightTransparency.SetActive(true);
        spotlight.color = flickerColor2;
        yield return new WaitForSeconds(.1f);
        spotlight.color = standardColor;

        yield return new WaitForSeconds(1);

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

        flashlightOn = false;
        starOutline.SetActive(true);
        flashlightClock = 0;
        mysteryBoxManager.CloseItem();
        mysteryBoxManager.ChangeCurrentItemID(1);

    }

    public void FlashLightStarted()
    {
        flashlightClock = 0;
        flashlightOn = true;
    }


    void CountdownFlashlight() 
    {

        flashlightClock += Time.deltaTime;

    }

    IEnumerator ShortFlicker()
    {

        spotlight.color = flickerColor2;

        yield return new WaitForSeconds(.3f);
        spotlight.color = standardColor;

        yield return new WaitForSeconds(.5f);
        spotlight.color = flickerColor2;

        yield return new WaitForSeconds(.5f);
        spotlight.color = standardColor;

        yield return new WaitForSeconds(.3f);

        spotlight.gameObject.SetActive(false);
        lightTransparency.SetActive(false);

        flashlightOn = false;
        flashlightClock = 0;
        mysteryBoxManager.CloseItem();
        mysteryBoxManager.ChangeCurrentItemID(1);

    }
}
