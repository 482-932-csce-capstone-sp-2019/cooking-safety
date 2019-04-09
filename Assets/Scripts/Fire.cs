using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {



	// Use this for initialization
	void Start () {
        ParticleSystem fire = this.GetComponent<ParticleSystem>();
        fire.Play();
    }
	
    public void Extinguish()
    {
        ParticleSystem fire = this.GetComponent<ParticleSystem>();
        fire.Stop();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
