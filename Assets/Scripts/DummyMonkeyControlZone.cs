using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMonkeyControlZone : MonoBehaviour
{
    public Transform moveTarget;



    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("DummyMonkey"))
        {

            other.gameObject.GetComponent<DummyMonkeyBehavior>().moveTarget = moveTarget;

        }

    }

}
