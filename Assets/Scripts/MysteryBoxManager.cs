using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBoxManager : MonoBehaviour
{
    public int currentItemID = 0;
    [SerializeField]
    public GameObject[] itemPictures;
    public GameObject[] itemObjects;
    public bool itemCurrentlyHeld = false;
    public bool itemCurrentlyInUse = false;

    public AudioSource useItemAudio;
    public AudioSource towerAudio;

    TowerBehavior towerBehavior;
    RollTheBall rollTheBall;
    WindUpKeyBehavior windUpKeyBehavior;


    [Header("Prefabs")]
    public GameObject windUpKeyPrefab;
    public Transform _windUpKeyTarget;

    public bool flashlightOn = false;

    private void Start()
    {
        towerBehavior = GameObject.FindObjectOfType<TowerBehavior>();
        rollTheBall = GameObject.FindObjectOfType<RollTheBall>();
        windUpKeyBehavior = GameObject.FindObjectOfType<WindUpKeyBehavior>();
    }


    private void Update()
    {
        if(itemCurrentlyHeld && !itemCurrentlyInUse)
        {

            if (Input.GetMouseButtonDown(1))
            {
                UseHeldItem();
            }
        }
    }

    public void ManuallySetItem()
    {

        itemPictures[currentItemID].SetActive(true);

    }  

    public void FindCurrentItem()
    {
        itemCurrentlyHeld = true;
        ManuallySetItem();


    }

    public void UseHeldItem()
    {
        useItemAudio.Play();
        itemCurrentlyInUse = true;

        //FLASHLIGHT
        if (currentItemID == 0)
        {
            flashlightOn = true;
            itemObjects[0].SetActive(true);



        }

        if(currentItemID == 1)
        {

            float keyDuration = 3;
            rollTheBall.CalculateBoost(1500, keyDuration);
            windUpKeyBehavior = Instantiate(windUpKeyPrefab).GetComponent<WindUpKeyBehavior>();
            windUpKeyBehavior.windUpKeyTarget = _windUpKeyTarget;



            windUpKeyBehavior.duration = keyDuration;
            windUpKeyBehavior.StartBoost();
            CloseItem();
        }

        if(currentItemID == 2)
        {

            towerBehavior.CalLTower();
            towerAudio.Play();

        }


    }

    public void CloseItem()
    {
        if (currentItemID == 0)
        {

            flashlightOn = false;
            itemObjects[0].SetActive(false);



        }

        if (currentItemID == 1)
        {

            // anything you'd want to do besides disable picture


        }

        itemCurrentlyHeld = false;
        itemCurrentlyInUse = false;
        itemPictures[currentItemID].SetActive(false);

    }

    public void ChangeCurrentItemID(int newItemID)
    {

        currentItemID = newItemID;
    }




}
