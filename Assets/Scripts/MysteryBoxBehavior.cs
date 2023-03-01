using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBoxBehavior : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource breakSound;
    bool played = false;
    public GameObject boxModel;
    public SkinnedMeshRenderer boxRenderer;
    public SkinnedMeshRenderer boxShadowRenderer;
    public SkinnedMeshRenderer starRenderer;
    public Material boxMaterialStandard;
    public Material boxMaterialBreak;
    public AnimationCurve easeCurve;
    ItemRoulette itemRoulette;
    MysteryBoxManager mysteryBoxManager;


    [Header("Items")]
    public GameObject flashlight;

    float resetTime = 15;

    Vector3 defaultScale;

    bool emptyBox = false;
    public bool towerBox = false;



    // Start is called before the first frame update
    void Start()
    {
        mysteryBoxManager = GameObject.FindObjectOfType<MysteryBoxManager>();
        itemRoulette = GameObject.FindObjectOfType<ItemRoulette>();
        defaultScale = transform.localScale;
    }



    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player") && !played)
        {
            played = true;

            if (!itemRoulette.rouletteOn && !mysteryBoxManager.itemCurrentlyHeld)
            {
                emptyBox = false;
                if (towerBox)
                {

                    mysteryBoxManager.currentItemID = 2;
                }
                itemRoulette.rouletteOn = true;
            }
            else
            {
                emptyBox = true;

            }
            StartCoroutine(GetSequence());
            StartCoroutine(BreakBox());

            


        }

    }

    IEnumerator GetSequence()
    {

        breakSound.Play();
        yield return new WaitForSeconds(.2f);




        if (!emptyBox)
        {
            audioSource.Play();
            yield return new WaitForSeconds(2.25f);
            itemRoulette.StopRoulette();
            FindCurrentItem();

        }


        yield break;

    }

    IEnumerator BreakBox()
    {

        float clock = 0;
        boxRenderer.material = boxMaterialBreak;

        while (clock < 1)
        {
            clock += Time.deltaTime * 2f;
            starRenderer.SetBlendShapeWeight(0, easeCurve.Evaluate(clock) * 100);
            boxRenderer.SetBlendShapeWeight(0, easeCurve.Evaluate(clock) * 100);
            boxShadowRenderer.SetBlendShapeWeight(0, easeCurve.Evaluate(clock) * 100);
            yield return null;
        }

        StartCoroutine(ResetBox());
        boxModel.SetActive(false);

    }

    void FindCurrentItem()
    {

        mysteryBoxManager.FindCurrentItem();



    }

    IEnumerator ResetBox()
    {
        float clock = 0;

        while (clock < resetTime)
        {

            clock += Time.deltaTime;
            yield return null;
        }
        boxModel.SetActive(true);
        boxRenderer.material = boxMaterialStandard;
        starRenderer.SetBlendShapeWeight(0, 0);
        boxRenderer.SetBlendShapeWeight(0, 0);
        boxShadowRenderer.SetBlendShapeWeight(0, 0);

        clock = 0;
        float reformTime = .7f;

        while (clock < reformTime) {

            clock += Time.deltaTime;
            transform.localScale = Vector3.Lerp(Vector3.zero, defaultScale, clock / reformTime);

                yield return null;

        }

        played = false;
    }

}
