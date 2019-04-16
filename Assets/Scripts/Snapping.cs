﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(FixedJoint))]
public class Snapping : Interactable {

    private SnapPoint snapPoint = null; 
    private Snapping CurrentSnapping = null;

    public override void Touched(Hand hand)
    {
        Unsnap();
        base.Touched(hand);
    }

    public override void Untouched(Hand hand)
    {
        base.Untouched(hand);
        Snap();
    }

    public override void Poked(Hand hand)
    {
        //Do nothing normally
    }

    void Snap()
    {
        CurrentSnapping = snapPoint.GetNearestSnapping();

        // Check if null
        if (!CurrentSnapping)
        {
            return;
        }

        //position
        transform.position = CurrentSnapping.GetSnapPoint().transform.position;
        GetComponent<Rigidbody>().isKinematic = true;

        CurrentSnapping.GetSnapPoint().Attach(this);
    }

    void Unsnap()
    {
        if(CurrentSnapping){
            CurrentSnapping.GetSnapPoint().Detach();
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    // Use this for initialization
    private void Awake()
    {
        snapPoint = GetComponentInChildren<SnapPoint>();
    }

    public SnapPoint GetSnapPoint(){
        return snapPoint;
    }
}
