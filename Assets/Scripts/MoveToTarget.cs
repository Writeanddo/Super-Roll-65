using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{

    public Transform followTarget;
    Rigidbody rb;
    public Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        //Debug
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.MovePosition(followTarget.position + _offset);
    }
}
