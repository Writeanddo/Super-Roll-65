using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text clockText;
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 540)
        {
            time += Time.deltaTime;
        }
        else
        {
            float multiplier = (time - 540) / 60;
            time += Time.deltaTime * (1 - multiplier);
        }
        CalculateTime();
    }

    void CalculateTime()
    {

        int minutes = (int)time / 60;
        int seconds = (int)time - 60 * minutes;
        int milliseconds = (int)(1000 * (time - minutes * 60 - seconds));
        clockText.text =  string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
