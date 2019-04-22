using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	ParticleSystem m_System;
    ParticleSystem.Particle[] m_Particles;
	
	private float extinguished = 1.0f;
	public  float extinguishing = 0.01f;
	private bool extinguish_change = false;
	private float fail_time = float.MaxValue;
	public bool failed = false;
	
    public void Extinguish()
    {
		extinguish_change = true;
		extinguished -= extinguishing;
		if(extinguished < 0.0f){
			extinguished = 0.0f;
		}
    }
	
	public void OnEnable(){
		fail_time = Time.timeSinceLevelLoad + 12.0f;
		print("OnEnabled called");
	}
	
	
	// Update is called once per frame
	void Update () {
		if(extinguished == 0.0f){
			m_System.Stop();
			gameObject.SetActive(false);
		}
		else if(failed == false && Time.timeSinceLevelLoad > fail_time){
			Results.Fail("You didn't put out the fire in time. FAIL");
			// Set flag to prevent multiple calls from being made
			failed = true;
		}
	}
	
	private void LateUpdate()
    {
        InitializeIfNeeded();
		
		if(!extinguish_change) return;
		
        // GetParticles is allocation free because we reuse the m_Particles buffer between updates
        int numParticlesAlive = m_System.GetParticles(m_Particles);

        // Change only the particles that are alive
        for (int i = 0; i < numParticlesAlive; i++)
        {
            m_Particles[i].startSize = extinguished;
        }

        // Apply the particle changes to the Particle System
        m_System.SetParticles(m_Particles, numParticlesAlive);
    }
	
	void InitializeIfNeeded()
    {
        if (m_System == null)
            m_System = GetComponent<ParticleSystem>();

        if (m_Particles == null || m_Particles.Length < m_System.main.maxParticles)
            m_Particles = new ParticleSystem.Particle[m_System.main.maxParticles];
    }
}
