using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DummyMonkeyBehavior : MonoBehaviour
{

    public Transform moveTarget;
    float chargeIncrements;
    public float charge = 0;
    public Rigidbody ballRb;
    Vector3 currentDirection;
    public float chargeReleaseTime = .5f;
    float chargeIntervals = 2;

    float clock = 0;

    public bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        clock = chargeIntervals - .1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            clock += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if(clock > chargeIntervals)
        {

            UpdateChargeInterval();
            CalculateDirection();
            RandomChargeCalculation();
            CalculateCharge();
            clock = 0;

        }

        if (charge > 0 && chargeIncrements != 0)
        {
            ApplyCharge();
        }
    }

    void RandomChargeCalculation()
    {

        charge = Random.Range(150, 500);
    }

    void UpdateChargeInterval()
    {

        chargeIntervals = Random.Range(1, 4);
    }

    void ApplyCharge()
    {
        // Charge Modifier to Reduce ability to add charge at very fast speeds
        float chargeModifier = 1;



        ballRb.AddForce(currentDirection * chargeIncrements * chargeModifier, ForceMode.Acceleration);
        charge -= chargeIncrements;

        if (charge <= 0)
        {

            charge = 0;
            chargeIncrements = 0;
        }

    }

    void CalculateDirection()
    {

        Vector3 targetAdjusted = moveTarget.position;
        targetAdjusted.y = 0;

        Vector3 positionAdjusted = ballRb.position;
        positionAdjusted.y = 0;


        currentDirection = Vector3.Normalize(targetAdjusted - positionAdjusted);



    }

    void CalculateCharge()
    {


        float fractionAmount = chargeReleaseTime / Time.fixedDeltaTime;
        chargeIncrements = charge / fractionAmount;
    }
}
