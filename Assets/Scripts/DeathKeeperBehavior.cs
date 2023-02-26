using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathKeeperBehavior : MonoBehaviour
{

    Transform _player;
    float height =5.92f;
    float standardHeight = 5.92f;
    float liftingHeight = 9;
    float targetHeight;
    public float moveSpeed = 10;
    public ConfigurableJoint hookJoint;
    public Transform rodEndPoint;
    public bool trackMonkey = false;
    public bool hookedMonkey = false;

    public bool monkeyInRange = false;

    public Vector3 arbitraryOffset = Vector3.zero;


    public bool poisonActive = true;


    public FixedJoint currentConnectJoint;

    bool audioPlayed = false;
    public AudioSource gotchaAudio;
    public AudioSource crashAudio;

    public GameObject crashScreen;



    // Start is called before the first frame update
    void Start()
    {
        targetHeight = standardHeight;
        _player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (trackMonkey)
        {
            MoveToMonkey();
        }

        if(hookedMonkey && poisonActive)
        {


        }



        SetHeight();
    }

    private void FixedUpdate()
    {



            SetHookAtBallHeight();
        if (hookedMonkey)
        {
            ReelInMonkey();

            if(!audioPlayed)
            {
                gotchaAudio.Play();
                audioPlayed = true;

            }

        }


    }

    void ReelInMonkey()
    {
        targetHeight = liftingHeight;
        Vector3 targetHookHeight = new Vector3(0, 2, 0);
        hookJoint.anchor = Vector3.MoveTowards(hookJoint.anchor, targetHookHeight, Time.fixedDeltaTime * 1.5f);
    }


    void MoveToMonkey()
    {


        targetHeight = _player.position.y + 4.64f;
        Vector3 newPosition = Vector3.MoveTowards(transform.position, _player.position + arbitraryOffset, moveSpeed * Time.deltaTime);
        newPosition.y = height;
        transform.position = newPosition;

    }



    void SetHookAtBallHeight()
    {


        Vector3 targetHookHeight = new Vector3(0,6.25f, 0);
        hookJoint.anchor = Vector3.MoveTowards(hookJoint.anchor, targetHookHeight, 1.25f * Time.fixedDeltaTime);

    }

    void SetHeight()
    {
        
        height = Mathf.MoveTowards(height, targetHeight, Time.deltaTime);
        if(hookedMonkey && height > 8 && poisonActive)
        {

            StartCoroutine(CrashScreenPlay());
            Debug.Log("|||||||||||||||||||DE|A|TTH|[]");

        }

    }


    public void CallDeathKeeper()
    {




        trackMonkey = true;
    }


    IEnumerator CrashScreenPlay()
    {
        crashScreen.SetActive(true);
        crashAudio.Play();
        yield return new WaitForSeconds(1);


        Application.Quit();
        yield break;

    }



}
