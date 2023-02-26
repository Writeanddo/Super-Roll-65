using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    public Material skyboxMat;
    public float rotValue;
    public float speed = -.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        rotValue += Time.deltaTime * speed;
        skyboxMat.SetFloat("_Rotation", rotValue);
    }
}
