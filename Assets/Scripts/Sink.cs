using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Valve.VR;
using UnityEngine;

namespace Assets.Scripts
{
    public class Sink : Interactable
    {
        private bool isRunning = false;
        public void Poke(Hand activating_hand)
        {
            ParticleSystem water = this.GetComponent<ParticleSystem>();
                // Turn on/off the sink
                if (isRunning)
                {
                    isRunning = false;
                /* Turn off sink
                 * 1. Turn off water effect. */
                water.Stop();
                }
                else
                {
                    isRunning = true;
                /* Turn on sink 
                 * 1. Turn on water effect. */
                water.Play();
                }
        }
     
    }
}