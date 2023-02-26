using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{

    public Transform doorTarget;
    public Rigidbody hingeRb;
    public Rigidbody doorRb;
    public MeshCollider doorCollider;


    private void Start()
    {
        doorCollider.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        hingeRb.MovePosition(doorTarget.position);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorRb.freezeRotation = false;
            doorCollider.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorRb.freezeRotation = true;
        }
    }


}
