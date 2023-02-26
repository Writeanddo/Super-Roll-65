using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public bool rotateAllAxis = false;
    public float rotateSpeed = 90;
    public Vector3 rotateVector;


    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!rotateAllAxis)
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(rotateVector * Time.deltaTime);
        }

    }
}
