using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UseItem : MonoBehaviour
{
    // Start is called before the first frame update
    TowerBehavior towerBehavior;
    MysteryBoxManager mysteryBoxManager;

    void Start()
    {
        towerBehavior = GameObject.FindObjectOfType<TowerBehavior>();   
    }

    /*
    // Update is called once per frame
    void Update()
    {
        HandleInput();
    } 

    void HandleInput()
    {

        if (Input.GetMouseButtonDown(1))
        {
            SummonTower();
        }
    }

    public void SummonTower()
    {
        towerBehavior.CalLTower();


    }
    */
    
}
