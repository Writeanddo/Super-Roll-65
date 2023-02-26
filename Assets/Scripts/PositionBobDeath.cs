using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBobDeath : MonoBehaviour
{
    public Transform rodEnd;
    public Transform hook;
    public DeathKeeperBehavior deathKeeperBehavior;
    float restingPoint = .5f;
    float currentPoint = .5f;



    // Update is called once per frame
    void Update()
    {

        if (!deathKeeperBehavior.hookedMonkey)
        {
            restingPoint = .5f;

        }
        else
        {
            restingPoint = .1f;


        }

        transform.position = Vector3.Lerp(rodEnd.position, hook.position, currentPoint);
        transform.rotation = Quaternion.LookRotation(transform.right, rodEnd.position - hook.position);

        currentPoint = Mathf.MoveTowards(currentPoint, restingPoint, Time.deltaTime * .25f);
    }
}
