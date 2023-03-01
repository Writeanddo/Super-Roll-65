using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollTheBall : MonoBehaviour
{
    public AudioSource rollAudio;

    float currentVolume = 0;
    float currentPitch = 1;
    public AnimationCurve volumeCurve;

    Camera mainCamera;
    Vector2 inputDirection;
    Vector3 camForward;
    Vector3 camRight;
    Vector3 moveDirection;
    // Start is called before the first frame update
    public Transform playerMonkey;
    public Rigidbody ballRb;
    public float charge = 0;
    public float chargeMultiplier = 5;
    public float chargeReleaseTime = .5f;
    public float maxCharge = 800;
    float chargeIncrements;
    float boostIncrements;
    public float velocityReading = 0;

    public float wasdPushForce = 3;


    float chargeAmount;

    public Image chargeAmountUI;

    bool mouseClickDown = false;

    public AudioSource chargeSound;
    public AudioSource boostSound;

    public bool boosting = false;
    float boostAmount;

    public bool inputActive = false;

    public bool debugOn = false;
    public Cinemachine.CinemachineVirtualCamera startingVirtualCamera;

    void Start()
    {
        mainCamera = Camera.main;

        if(debugOn)
        {
            inputActive = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            startingVirtualCamera.enabled = false;
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (inputActive)
        {
            HandleInput();
            HandleMouse();
        }
        UpdateUI();
       AdjustRollNoise();


    }

    private void FixedUpdate()
    {
        velocityReading = ballRb.velocity.magnitude;
        ApplyForce();
        if(charge > 0 && chargeIncrements != 0)
        {
            ApplyCharge();
        }

        //boost area

        if(boosting)
        {
            ApplyBoost();

        }
    }

    void HandleInput()
    {

 

            inputDirection.x = Input.GetAxis("Horizontal");
            inputDirection.y = Input.GetAxis("Vertical");


            camForward = mainCamera.transform.forward;
            camForward = new Vector3(camForward.x, 0, camForward.z);



            camRight = mainCamera.transform.right;


            camRight = new Vector3(camRight.x, 0, camRight.z);


            moveDirection = Vector3.zero;

            // Calculate new move direction

            moveDirection += inputDirection.x * camRight;
            moveDirection += inputDirection.y * camForward;
        



    }

    void HandleMouse()
    {

        if (Input.GetMouseButton(0))
        {
            if (!mouseClickDown)
            {
                chargeSound.Play();
                mouseClickDown= true;
            }

            charge += Time.deltaTime * chargeMultiplier;
            charge = Mathf.Clamp(charge, 0, maxCharge);
        }

        if (Input.GetMouseButtonUp(0))
        {

            mouseClickDown = false;
            CalculateCharge();
        }



    }


    public void CalculateBoost(float _boostAmount,float _boostTime)
    {
        boosting = true;
        boostAmount = _boostAmount;
        float fractionAmount = _boostTime / Time.fixedDeltaTime;
        boostIncrements = boostAmount / fractionAmount;
    }

    void ApplyBoost()
    {
        ballRb.AddForce(playerMonkey.forward * boostIncrements, ForceMode.Acceleration);
        boostAmount -= boostIncrements;

        if(boostAmount <= 0)
        {
            boostIncrements = 0;
            boosting = false;
        }
    }

    void CalculateVelocityModifier()
    {


    }

    void ApplyCharge()
    {
        // Charge Modifier to Reduce ability to add charge at very fast speeds
        float chargeModifier = 1;

        if(velocityReading > 15)
        {
            float mathVelocity = velocityReading - 15;

            chargeModifier = 1 - (Mathf.Clamp01(mathVelocity / 5));
        }

        ballRb.AddForce(camForward * chargeIncrements * chargeModifier, ForceMode.Acceleration);
        charge -= chargeIncrements;

        if(charge <= 0)
        {

            charge = 0;
            chargeIncrements = 0;
        }

    }

    void CalculateCharge()
    {
        chargeSound.Stop();

        boostSound.volume = Mathf.Lerp(.15f, .4f, charge / 800);
        boostSound.Play();



        float fractionAmount = chargeReleaseTime / Time.fixedDeltaTime;
        chargeIncrements = charge / fractionAmount;
    }

    void ApplyForce()
    {

        float chargeModifier = 1;
        if (velocityReading > 17)
        {
            float mathVelocity = velocityReading - 15;

            chargeModifier = 1 - (Mathf.Clamp01(mathVelocity / 5));
        }

        ballRb.AddForce(moveDirection * wasdPushForce * 50 * Time.fixedDeltaTime * chargeModifier);
        
    }

    void UpdateUI()
    {
        chargeAmountUI.fillAmount = charge / 800;

    }


    
    void AdjustRollNoise()
    {
        currentVolume = Mathf.MoveTowards(currentVolume, Mathf.Lerp(0, .5f, volumeCurve.Evaluate(velocityReading / 20)), Time.deltaTime * 2);
        currentPitch = Mathf.MoveTowards(currentVolume, Mathf.Lerp(2, 2.5f, volumeCurve.Evaluate(velocityReading / 20)), Time.deltaTime * 2);

        rollAudio.volume = currentVolume;
        rollAudio.pitch = currentPitch; 
    }

    
    
}
