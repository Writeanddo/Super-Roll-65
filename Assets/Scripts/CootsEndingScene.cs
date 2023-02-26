using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CootsEndingScene : MonoBehaviour
{
    public GameObject blackoutScreen;
    public GameObject[] textLines;
    public TearBehavior[] tears;
    public GameObject openMouth;
    public SkinnedMeshRenderer pupilRenderer;
    public AnimationCurve easeCurve;
    public AnimationCurve easeCurve2;

    public AnimationCurve easeOutCurve;
    public AnimationCurve standardEaseCurve;
    public Volume brightOutPost;

    public float talkDuration = 1.5f;

    float mouthFlapInterval = .1f;
    float mouthFlapTime = 0;

    [Header("MonkeyStuff")]
    public Transform monkey;
    public Transform monkeyModel;
    public Transform cootsHand;
    Vector3 defaultMonkeyPosition;
    float lowPointY = -4.39f;
    float grabPointY = -0.55f;
    float restingPointY = .33f;
    float peakY = 1.25f;

    bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(CryTears());
        //StartCoroutine(FlapCootsMouth(talkDuration));
        //StartCoroutine(WidenCootsEyes());
        //StartCoroutine(AdjustFogDistance());
        brightOutPost.weight = 0;
        defaultMonkeyPosition = monkey.position;
        cootsHand.gameObject.SetActive(false);
          RenderSettings.fogEndDistance = 1;
        StartCoroutine(RunScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CryTears()
    {

        tears[0].tearActive= true;

        yield return new WaitForSeconds(1);
        tears[1].tearActive = true;
        yield return new WaitForSeconds(1.5f);
        tears[2].tearActive = true;
        yield return new WaitForSeconds(.5f);
        tears[3].tearActive = true;

        yield return new WaitForSeconds(2f);
        tears[4].tearActive = true;
        yield return new WaitForSeconds(1);
        tears[5].tearActive = true;
        yield return new WaitForSeconds(.8f);
        tears[6].tearActive = true;
        yield return new WaitForSeconds(1.7f);
        tears[7].tearActive = true;

        yield break;
    }





    IEnumerator FlapCootsMouth(float _talkDuration)
    {
        float clock = 0;
        mouthFlapTime = mouthFlapInterval;


        while(clock < _talkDuration)
        {
            clock += Time.deltaTime;
            mouthFlapTime += Time.deltaTime;

            if(mouthFlapTime > mouthFlapInterval)
            {

                open = !open;

                if(open)
                {
                    openMouth.SetActive(true);
                }
                else
                {
                    openMouth.SetActive(false);
                }

                mouthFlapTime = 0;
                mouthFlapInterval = Random.Range(.15f, .15f);

            }


            yield return null;
        }

        while (mouthFlapTime < .25f)
        {
            mouthFlapTime += Time.deltaTime;
            yield return null;
        }
        openMouth.SetActive(false);

    }

    IEnumerator WidenCootsEyes()
    {

        /*
        float clock = 1;

        while(clock > 0)
        {

            clock -= Time.deltaTime;

            pupilRenderer.SetBlendShapeWeight(0, easeCurve.Evaluate(clock) * 100);
        }

        */



        float clock = 0;

        while(clock < 1)
        {

            clock += Time.deltaTime * .45f;

            pupilRenderer.SetBlendShapeWeight(0, easeCurve.Evaluate(1 - clock) * 100);

            yield return null;
        }

        
        yield break;


    }

    IEnumerator AdjustFogDistance()
    {
        float clock = 0;
        Debug.Log("adjust fog");
        while (clock < 1)
        {
            clock += Time.deltaTime * .15f;
            RenderSettings.fogEndDistance = Mathf.Lerp(1, 4, easeCurve.Evaluate(clock));

            yield return null;
        }



        yield break;
    }

    IEnumerator RunScene()
    {
        yield return new WaitForSeconds(.5f);
        blackoutScreen.SetActive(false);
        StartCoroutine(MonkeyArc());

        yield return new WaitForSeconds(29);


        Debug.Log("run scene called");
        StartCoroutine(AdjustFogDistance());

        yield return new WaitForSeconds(4);
        StartCoroutine(WidenCootsEyes());

        yield return new WaitForSeconds(4);
        StartCoroutine(FlapCootsMouth(1.5f));

        yield return new WaitForSeconds(.4f);
        textLines[0].SetActive(true);

        yield return new WaitForSeconds(4);

        textLines[0].SetActive(false);

        yield return new WaitForSeconds(1);
        StartCoroutine(FlapCootsMouth(2));

        yield return new WaitForSeconds(.1f);
        textLines[1].SetActive(true);

        yield return new WaitForSeconds(4);

        textLines[1].SetActive(false);

        yield return new WaitForSeconds(1);
        StartCoroutine(FlapCootsMouth(1.5f));


        yield return new WaitForSeconds(.1f);
        textLines[2].SetActive(true);

        yield return new WaitForSeconds(2);
        //StartCoroutine(CryTears());

        yield return new WaitForSeconds(2);

        textLines[2].SetActive(false);

        yield return new WaitForSeconds(1);
        StartCoroutine(FlapCootsMouth(1.5f));
        textLines[3].SetActive(true);

        yield return new WaitForSeconds(4);

        textLines[3].SetActive(false);

        yield return new WaitForSeconds(1);
        StartCoroutine(FlapCootsMouth(1.5f));
        textLines[4].SetActive(true);
        StartCoroutine(BlindOut());



        yield break;


    }

    IEnumerator BlindOut()
    {

        float clock = 0;

        while(clock < 1)
        {

            clock += Time.deltaTime * .1f;
            brightOutPost.weight = easeCurve2.Evaluate(clock);

            yield return null;

        }

        Application.Quit();


        yield break;
    }

    IEnumerator MonkeyArc()
    {

        float clock = 0;
        float riseDuration = 17;
        Vector3 startingSpot = defaultMonkeyPosition;
        startingSpot.y = -4.39f;
        Vector3 targetSpot = defaultMonkeyPosition;
        targetSpot.y = 1.25f;

        Vector3 initialSpin = new Vector3(25, 25, 40);
        Vector3 currentSpin;

        while (clock < riseDuration)
        {

            clock += Time.deltaTime;

            Vector3 newSpot = Vector3.Lerp(startingSpot, targetSpot, easeCurve.Evaluate(clock / riseDuration));


            currentSpin = Vector3.Lerp(initialSpin, Vector3.zero,easeOutCurve.Evaluate(clock / riseDuration));

            monkeyModel.Rotate(currentSpin * Time.deltaTime);

            monkey.position = newSpot;

            yield return null;
        }

        clock = 0;
        riseDuration = 10;

        startingSpot = monkey.position;
        cootsHand.gameObject.SetActive(true);

        targetSpot = defaultMonkeyPosition;
        targetSpot.y =.33f;

        Quaternion initialRotation= monkeyModel.rotation;

        while (clock < riseDuration)
        {

            clock += Time.deltaTime;

            Vector3 newSpot = Vector3.Lerp(startingSpot, targetSpot, easeCurve.Evaluate(clock / riseDuration));




            monkey.position = newSpot;


            monkeyModel.rotation = Quaternion.Lerp(initialRotation, Quaternion.identity, easeCurve.Evaluate(clock / riseDuration));

            yield return null;
        }




    }




}
