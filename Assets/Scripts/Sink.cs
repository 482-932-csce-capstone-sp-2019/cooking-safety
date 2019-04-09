using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Valve.VR;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Sink : Interactable
{
    ParticleSystem water;
    private bool isRunning = false;

    public void Awake()
    {
        water = GetComponentInChildren<ParticleSystem>();
        water.Stop();
    }

    public void OnCollisionEnter(Collision collision)
    {
        var temp = collision.gameObject.GetComponent<Hand>();
        if (temp)
            temp.handState.clean();
    }

    public override void Touched(Hand hand)
    {
        //Do Nothing
    }

    public override void Untouched(Hand hand)
    {
        //Do Nothing
    }

    public override void Poked(Hand activating_hand)
    {
        print("sink poked");
        ToggleFaucet();
    }

    private void ToggleFaucet()
    {
        if (isRunning)
        {
            isRunning = false;
            water.Stop();
        }
        else
        {
            isRunning = true;
            water.Play();
        }
    }
}