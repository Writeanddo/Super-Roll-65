using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindUpKeyBehavior : MonoBehaviour
{

    public Transform windUpKeyTarget;
    public Transform windUpKeyHolder;
    public Vector3 rotateSpeed = new Vector3(0, 0, 720);
    public float rotateSpeedFloat = 720f;
    public Transform player;
    public BoxCollider boxCollider;
    Rigidbody rb;
    public float duration = 4;
    float clock = 0;

    public AudioSource firstSound;
    public AudioSource secondSound;
    public MysteryBoxManager mysteryBoxManager;
    public MeshRenderer meshRenderer;


    public bool active = false;
    bool firstFrame = true;

    int frameCount;

    // Start is called before the first frame update
    void Awake()
    {
        
        boxCollider.enabled = false;
        player = GameObject.FindGameObjectWithTag("PlayerMonkey").transform;
        rb =GetComponent<Rigidbody>();





    }



    // Update is called once per frame
    void Update()
    {
        if(active)
        {

            windUpKeyHolder.Rotate(rotateSpeed * Time.deltaTime);


        }


    }

    public void SetupFirstPosition()
    {
        rb.position = windUpKeyTarget.position; 
    }


    void FixedUpdate()
    {

            if (active)
            {

            if (frameCount == 5)
            {
                rb.interpolation = RigidbodyInterpolation.Extrapolate;
            }


                rb.MovePosition(windUpKeyTarget.position);

                rb.MoveRotation(player.rotation);

                clock += Time.deltaTime;

                if (clock > duration)
                {

                    active = false;
                    ShedKey();

                }


            frameCount += 1;

            }

        
        

    }

    void ShedKey()
    {
        Debug.Log("SHED KEY CALLED");
        active = false;
        rb.useGravity = true;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.isKinematic = false;
        boxCollider.enabled = true;
        StartCoroutine(SleepKey());
    }

    IEnumerator SleepKey()
    {

        yield return new WaitForSeconds(8);
        rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        


        yield break;

    }


    public void StartBoost()
    {
        rb.position = windUpKeyTarget.position;
        StartCoroutine(TheSound());
        active = true;

    }

    IEnumerator TheSound()
    {

        firstSound.Play();
        yield return new WaitForSeconds(2.2f);
        secondSound.Play();
    }


}
