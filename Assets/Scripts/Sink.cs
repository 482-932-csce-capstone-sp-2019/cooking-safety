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
        water = this.GetComponent<ParticleSystem>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Hand>().handState.clean();
    }

    public void Poke(Hand activating_hand)
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