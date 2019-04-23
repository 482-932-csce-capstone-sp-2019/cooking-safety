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
    public List<Thermometer> Thermometers = new List<Thermometer>();
    public List<Hand> Hands = new List<Hand>();

    public void Awake()
    {
        water = GetComponentInChildren<ParticleSystem>();
        water.Stop();
    }

    public void Update()
    {
      if (isRunning)
      {
        foreach(Thermometer t in Thermometers){
				  t.last_touched = Thermometer.State.None;
        }
        foreach(Hand h in Hands){
          h.handState.clean();
        }
      }
    }

    public void OnTriggerEnter(Collider collider)
    {
        var hand = collider.gameObject.GetComponent<Hand>();
        if(hand){
          Hands.Add(hand);
          return;
        }
        var thermometer = collider.GetComponent<Thermometer>();
        if(thermometer){
          Thermometers.Add(thermometer);
          return;
        }
    }
	
	public void OnTriggerExit(Collider collider)
    {
        var hand = collider.gameObject.GetComponent<Hand>();
        if(hand){
          Hands.Remove(hand);
          return;
        }
        var thermometer = collider.GetComponent<Thermometer>();
        if(thermometer){
          Thermometers.Remove(thermometer);
          return;
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