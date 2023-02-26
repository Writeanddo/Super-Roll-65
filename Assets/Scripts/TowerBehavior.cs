using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TowerBehavior : MonoBehaviour
{
    Rigidbody towerRb;
    bool towerActive = false;
    bool towerPositioned = false;
    Vector3 towerMoveSpeed = new Vector3(0, 8, 0);
    public Transform monkeyTarget;
    Transform player;
    Vector3 offsetOfMonkeyTarget;
    Vector3 towerXZPosition;

    public AnimationCurve easeOutCurve;
    public AnimationCurve easeOutCurveXZ;

    float movementModifier = 1;
    float movementModifierXZ = 1;

    public CinemachineVirtualCamera mainVirtualCamera;
    public CinemachineVirtualCamera shakeVirtualCamera;
    public CinemachineVirtualCamera endVirtualCamera;



    // Start is called before the first frame update
    void Start()
    {

     towerRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        towerXZPosition = transform.position;
        towerXZPosition.y = 0;
        

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if(towerActive)
        {
            if (!towerPositioned)
            {
                SetInitialPosition();
            }
            else
            {
                MoveTower();
            }

        }
        
    }

    public void CalLTower()
    {

        towerActive = true;

        StartCoroutine(StopShake());


    }

    void SetInitialPosition()
    {
        towerPositioned = true;

        Vector3 towerAdjustedPosition = transform.position;
        towerAdjustedPosition.y = 0;
        Vector3 playerAdjustedPosition = player.position;
        playerAdjustedPosition.y = 0;
        Vector3 targetAdjustedPosition = monkeyTarget.position;
        targetAdjustedPosition.y = 0;



        Vector3 monkeyTargetDirection = playerAdjustedPosition - targetAdjustedPosition;


        offsetOfMonkeyTarget = targetAdjustedPosition - towerAdjustedPosition;

        towerXZPosition = Vector3.MoveTowards(towerXZPosition, towerXZPosition + monkeyTargetDirection, Time.fixedDeltaTime * 100);




        Vector3 horizontalNewPosition = towerXZPosition;
        Vector3 verticalNewPosition = new Vector3(0, -125, 0);

        towerRb.position = horizontalNewPosition + verticalNewPosition;

    }

    void MoveTower()
    {




        Vector3 towerAdjustedPosition = transform.position;
        towerAdjustedPosition.y = 0;
        Vector3 playerAdjustedPosition = player.position;
        playerAdjustedPosition.y = 0;
        Vector3 targetAdjustedPosition = monkeyTarget.position;
        targetAdjustedPosition.y = 0;



        Vector3 monkeyTargetDirection = playerAdjustedPosition - targetAdjustedPosition;

        //test normal center;
        //Vector3 monkeyTargetDirection = playerAdjustedPosition - towerAdjustedPosition

        offsetOfMonkeyTarget = targetAdjustedPosition - towerAdjustedPosition;

        towerXZPosition = Vector3.MoveTowards(towerXZPosition, towerXZPosition + monkeyTargetDirection, Time.fixedDeltaTime * 40 * movementModifierXZ);




        Vector3 verticalNewPosition = towerRb.position + (towerMoveSpeed * Time.fixedDeltaTime * movementModifier);
        Vector3 horizontalNewPosition = towerXZPosition - towerAdjustedPosition;

        //towerRb.MovePosition(((towerRb.position + towerMoveSpeed) * Time.fixedDeltaTime) + (towerXZPosition - offsetOfMonkeyTarget));
        towerRb.MovePosition(verticalNewPosition +  horizontalNewPosition);

        movementModifier = easeOutCurve.Evaluate((transform.position.y + 100) / 100);
        movementModifierXZ = easeOutCurveXZ.Evaluate((transform.position.y + 100) / 100);

        
    }


    IEnumerator StopShake()
    {
        mainVirtualCamera.enabled = false;
        shakeVirtualCamera.enabled = true;

        yield return new WaitForSeconds(10);
        mainVirtualCamera.enabled = true;
        shakeVirtualCamera.enabled = false;

    }

    public void SetEndCamera()
    {
        mainVirtualCamera.enabled = false;
        endVirtualCamera.enabled = true;

    }
}
