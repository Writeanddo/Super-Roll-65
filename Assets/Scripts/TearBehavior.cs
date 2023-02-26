using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearBehavior : MonoBehaviour
{

    public Transform tearDropTarget;
    public Transform tearDropStart;
    public AnimationCurve easeIn;
    Vector3 targetScale;

    bool tearFormed = false;
    public bool tearActive = false;
    float sizeRandomizer = 1;

    float clock = 0;
    // Start is called before the first frame update
    void Awake()
    {
        targetScale = transform.localScale;
        transform.localScale = Vector3.zero;
        sizeRandomizer = Random.Range(.6f, 1f);
        transform.position = tearDropStart.position;
    }


    private void Update()
    {
        if(tearActive)
        {
            
            if (!tearFormed)
            {
                clock += Time.deltaTime * .75f;
                GrowTear();
            }
            else
            {
                clock += Time.deltaTime * .25f;
                DropTear();


            }

        }
    }

    void GrowTear()
    {

        transform.localScale = Vector3.Lerp(Vector3.zero,targetScale * sizeRandomizer, clock);


        if(clock >= 1)
        {
            
            tearFormed= true;
        }

    }

    void DropTear()
    {
        transform.position = Vector3.Lerp(tearDropStart.position, tearDropTarget.position, easeIn.Evaluate(clock - 1));

        if(clock >= 2)
        {

            tearActive = false;


        }

    }

}
