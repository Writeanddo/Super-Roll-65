using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRigidbody : MonoBehaviour
{

    Rigidbody rb;
    public Vector3 rotateSpeed = new Vector3(0,30,0);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Quaternion deltaRotation = Quaternion.Euler(rotateSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
