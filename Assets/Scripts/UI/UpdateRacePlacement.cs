using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateRacePlacement : MonoBehaviour
{
    [SerializeField]
    public Vector2[] positionBrackets;
    [SerializeField]
    public string[] places;

    [SerializeField]
    public Vector2[] horizontalBrackets;

    [SerializeField]

    public Text placeText;

    float updateInterval = 1;
    float clock = 0;

    public Transform player;
    float playerZPosition;
    float playerXPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        RunPlaceUpdate();
        clock = updateInterval;
    }

    // Update is called once per frame
    void Update()
    {

        clock += Time.deltaTime;
        if(clock > updateInterval)
        {
            playerZPosition = player.position.z;
            playerXPosition = player.position.x;
            RunPlaceUpdate();
            clock = 0;
        }
    }

    void RunPlaceUpdate()
    {

        for (int i = 0; i < places.Length; i++)
        {


            if (playerZPosition >= positionBrackets[i].x && playerZPosition <= positionBrackets[i].y)
            {

                placeText.text = places[i];

            }

            if(playerZPosition > -70f && playerZPosition < 90)
            {

                if(Mathf.Abs(playerXPosition) > 100)
                {
                    placeText.text = places[9];

                }
                if (Mathf.Abs(playerXPosition) > 200)
                {
                    placeText.text = places[14];

                }
                if (Mathf.Abs(playerXPosition) > 300)
                {
                    placeText.text = places[0];

                }
                if (Mathf.Abs(playerXPosition) > 300)
                {
                    placeText.text = places[12];

                }


            }

        }

    }
}
