using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyPathController : MonoBehaviour
{
    public Vector3 [] positions;
    public float speed;

    private uint ind;
    private Boolean forward;

    void Start ()
    {
        ind = 0;
        positions[ind] = transform.localPosition;
    }

    void FixedUpdate ()
    {
        if (ind == 0) forward = true;
        else if (ind == positions.Length - 1) forward = false;

        uint nxtInd = ind + 1;
        if (!forward) nxtInd = ind - 1;

        if (Vector3.Distance(transform.localPosition, positions[nxtInd]) > 0.5)
        {
            Vector3 diff = positions[nxtInd] - positions[ind];;

            if (diff.magnitude < speed) transform.localPosition = positions[nxtInd];
            else transform.position += diff.normalized * speed;
        }
        else ind = nxtInd;
    }
}
