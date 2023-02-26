using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToFinalScene : MonoBehaviour
{

    public bool trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger)
        {
            CallFinalScene();
        }
    }

    private void CallFinalScene()
    {



        SceneManager.LoadScene(1);
    }
}
