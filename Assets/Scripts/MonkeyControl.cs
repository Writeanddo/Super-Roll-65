using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyControl : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody ballRb;
    public Vector3 moveDirection;
    public float rotateSpeed = 720;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim.SetFloat("speed", 0);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotation();
    }


    void UpdateRotation()
    {

        moveDirection = ballRb.velocity;
        moveDirection.y = 0;
        float ballMagnitude = moveDirection.magnitude;


        if (ballMagnitude > .1f)
        {
            playerTransform.rotation = Quaternion.RotateTowards(playerTransform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * rotateSpeed);

            anim.SetFloat("speed", ballMagnitude * .4f);
        }


    }


}
