using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeySounds : MonoBehaviour
{

    public AudioSource rightFootAudio;
    public AudioSource leftFootAudio;

    public void RightFoot()
    {


        rightFootAudio.Play();

    }

    public void LeftFoot()
    {


        leftFootAudio.Play();

    }
}
