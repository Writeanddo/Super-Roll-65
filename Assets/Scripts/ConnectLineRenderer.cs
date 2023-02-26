using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectLineRenderer : MonoBehaviour
{

    public Transform[] connections;
    public LineRenderer lineRenderer;


    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, connections[0].position);
        lineRenderer.SetPosition(1, connections[1].position);
    }
}
