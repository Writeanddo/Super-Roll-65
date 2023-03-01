using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimekeeperBehavior : MonoBehaviour
{

    Transform _player;
    Rigidbody rb;
    float height = 5.92f;
    float standardHeight = 5.92f;
    float liftingHeight = 9;
    float targetHeight;
    public float moveSpeed = 10;
    public ConfigurableJoint hookJoint;
    public Transform rodEndPoint;
    public bool trackMonkey = false;
    public bool hookedMonkey = false;
    float dropOffClock = 0;
    float dropOffClockDefault = 0;
    public bool monkeyInRange = false;
    public bool monkeyNeedsSavingFlag = false;

    public bool monkeyInZone1 = false;
    public bool monkeyInZone2 = false;
    public bool monkeyInZone3 = false;  
    public bool playerInZone1 = false;
    public bool playerInZone2 = false;
    public bool playerInZone3 = false;
    public bool playerInZone4 = false;

    public Transform dropOffTarget;
    public Transform zone1Target;
    public Transform zone2Target;
    public Transform zone3Target;
    public Transform zone4Target;
    public FixedJoint currentConnectJoint;

    public AudioSource hookSound;




    // Start is called before the first frame update
    void Start()
    {
        targetHeight = liftingHeight;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {



        if (monkeyInZone1 || monkeyInZone2 || monkeyInZone3 || playerInZone1 || playerInZone2 || playerInZone3 || playerInZone4)
        {
            monkeyNeedsSavingFlag = true;
        }
        else
        {
            monkeyNeedsSavingFlag = false;
        }

        if (monkeyNeedsSavingFlag && !hookedMonkey)
        {
            MoveToSandZone();
        }
        if (hookedMonkey)
        {
            trackMonkey = false;
            MoveToDropOff();
        }

        SetHeight();
        if (transform.position.y < targetHeight)
        {
            RestingSetPosition();
        }

        if (hookedMonkey)
        {
            ReelInMonkey();

        }
        else
        {
            if (trackMonkey || monkeyNeedsSavingFlag)
            {
                if (monkeyInRange)
                {
                    SetHookAtBallHeight();
                }
                else
                {
                    ReelInMonkey();
                }
            }


        }





    }

    void MoveToSandZone()
    {

        Vector3 newPosition = transform.position;

        if (playerInZone1)
        {

            newPosition = Vector3.MoveTowards(transform.position, zone1Target.position, moveSpeed * Time.deltaTime);
        }
        else if (playerInZone2)
        {
            newPosition = Vector3.MoveTowards(transform.position, zone2Target.position, moveSpeed * Time.deltaTime);


        }

        else if (playerInZone3)
        {
            newPosition = Vector3.MoveTowards(transform.position, zone2Target.position, moveSpeed * Time.deltaTime);


        }
        else if (playerInZone4)
        {
            newPosition = Vector3.MoveTowards(transform.position, zone4Target.position, moveSpeed * Time.deltaTime);


        }
        else {
            if (monkeyInZone1)
            {
                newPosition = Vector3.MoveTowards(transform.position, zone1Target.position, moveSpeed * Time.deltaTime);


            }
            else if (monkeyInZone2)
            {
                newPosition = Vector3.MoveTowards(transform.position, zone2Target.position, moveSpeed * Time.deltaTime);

            }
            else if (monkeyInZone3)
            {
                newPosition = Vector3.MoveTowards(transform.position, zone3Target.position, moveSpeed * Time.deltaTime);

            }
        }


        newPosition.y = height;
        rb.MovePosition(newPosition);



    }



    void SetHookAtBallHeight()
    {
        Vector3 targetHookHeight;



            targetHookHeight = new Vector3(0, 8.75f, 0);



        hookJoint.anchor = Vector3.MoveTowards(hookJoint.anchor, targetHookHeight, 1.25f * Time.fixedDeltaTime);

    }

    void ReelInMonkey()
    {
        targetHeight = liftingHeight;
        Vector3 targetHookHeight = new Vector3(0, 2, 0);
        hookJoint.anchor = Vector3.MoveTowards(hookJoint.anchor, targetHookHeight, Time.fixedDeltaTime * 2);
    }

    void SetHeight()
    {
        height = Mathf.MoveTowards(height, targetHeight, Time.deltaTime);

    }

    void RestingSetPosition()
    {

        //Vector3 newPosition = Vector3.MoveTowards(transform.position, _player.position, moveSpeed * Time.deltaTime);
        Vector3 newPosition = transform.position;
        newPosition.y = height;
        rb.MovePosition(newPosition);
    }

    private void MoveToDropOff()
    {
        if (hookJoint.anchor.y < 2.5f)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, dropOffTarget.position, moveSpeed * Time.deltaTime *.5f);
            newPosition.y = height;
            rb.MovePosition(newPosition);

            Vector3 adjustedPosition = transform.position;
            adjustedPosition.y = dropOffTarget.position.y;

            if(Vector3.Distance(adjustedPosition,dropOffTarget.position) < 2)
            {

                DropOffCountdown();
            }
            else
            {
                dropOffClock = dropOffClockDefault;
            }

        }


    }

    void DropOffCountdown()
    {

        dropOffClock -= Time.deltaTime;

        if(dropOffClock <= 0)
        {
            hookedMonkey = false;
            Destroy(currentConnectJoint);
        }
    }



}
