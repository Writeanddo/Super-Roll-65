using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookConnectionBehavior : MonoBehaviour
{

    public TimekeeperBehavior timeKeeperBehavior;
    public Transform hookEndTarget;
    public Rigidbody hookRb;
    Rigidbody detectorRb;
    Rigidbody ballRb;
    FixedJoint connectionJoint;
    bool hooked = false;

    // Start is called before the first frame update
    void Start()
    {
        detectorRb= GetComponent<Rigidbody>(); 
    }

    private void FixedUpdate()
    {
        detectorRb.MovePosition(hookEndTarget.position);
        detectorRb.MoveRotation(hookEndTarget.rotation);
        
        if(connectionJoint == null) {
            hooked = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (!hooked)
        {
            ballRb = other.transform.parent.GetComponent<Rigidbody>();

            connectionJoint = ballRb.gameObject.AddComponent<FixedJoint>();
            connectionJoint.connectedBody = hookRb;
            connectionJoint.enablePreprocessing = false;
            hooked = true;
            timeKeeperBehavior.trackMonkey = false;
            timeKeeperBehavior.hookedMonkey= true;
            timeKeeperBehavior.currentConnectJoint = connectionJoint;


        }

    }
}
