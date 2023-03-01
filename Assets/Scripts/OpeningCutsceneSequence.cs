using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class OpeningCutsceneSequence : MonoBehaviour
{

    public AudioSource phonecallAudio;
    public AudioSource readySetAudio;
    public AudioSource courseMusic;
    public GameObject[] titleCards;

    public AudioSource timekeeperAudio;

    public DummyMonkeyBehavior[] dummyMonkeys;

    UIManager uiManager;
    RollTheBall rollTheBall;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.FindObjectOfType<UIManager>();
        rollTheBall= GameObject.FindObjectOfType<RollTheBall>();
        rollTheBall.inputActive = false;
        titleCards[7].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginSequence()
    {

        StartCoroutine(OpeningSequence());

    }

    IEnumerator OpeningSequence()
    {

        yield return new WaitForSeconds(.2f);
        titleCards[0].SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        yield return new WaitForSeconds(2);

        titleCards[1].SetActive(true);

        phonecallAudio.Play();

        yield return new WaitForSeconds(22.5f);

        titleCards[1].SetActive(false);

        yield return new WaitForSeconds(3);
        titleCards[2].SetActive(true);

        yield return new WaitForSeconds(2);
        titleCards[2].SetActive(false);
        yield return new WaitForSeconds(1);
        titleCards[3].SetActive(true);

        yield return new WaitForSeconds(2.65f);

        titleCards[3].SetActive(false);

        yield return new WaitForSeconds(1);

        titleCards[4].SetActive(true);
        yield return new WaitForSeconds(5.1f);

        titleCards[4].SetActive(false);

        yield return new WaitForSeconds(2);

        readySetAudio.Play();

        titleCards[5].SetActive(true);

        yield return new WaitForSeconds(2);
        titleCards[5].SetActive(false);
        titleCards[6].SetActive(true);
        yield return new WaitForSeconds(1.8f);

        uiManager.time = 0;
        titleCards[7].SetActive(false);

        titleCards[8].SetActive(true);
        titleCards[9].SetActive(false);
        courseMusic.Play();
        rollTheBall.inputActive = true;
        timekeeperAudio.Play();

        for(int i = 0; i < dummyMonkeys.Length; i++)
        {

            dummyMonkeys[i].active = true;

        }


        yield return new WaitForSeconds(2);

        titleCards[8].SetActive(false);
        

        yield break;

    }
}
