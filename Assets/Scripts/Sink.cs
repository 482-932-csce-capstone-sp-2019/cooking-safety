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

    public void OnTriggerEnter(Collider collider)
    {
        var hand = collider.gameObject.GetComponent<Hand>();
        if (hand && isRunning)
        {
            hand.handState.clean();
        }
		else
		{
			Thermometer thermometer = collider.GetComponent<Thermometer>();
			if(thermometer && isRunning)
			{
				thermometer.last_touched = Thermometer.State.None;
			}
		}
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