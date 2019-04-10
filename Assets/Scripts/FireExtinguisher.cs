﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FireExtinguisher : MonoBehaviour {
    ParticleSystem part;
    public SteamVR_Action_Boolean m_ActivateAction = null;
    private bool lastFrameOn = false;
    public List<ParticleCollisionEvent> collisionEvents;
    // Use this for initialization
    void Awake ()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other) {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        int i = 0;
        while (i < numCollisionEvents)
        {
            if (other.tag == "Fire")
            {
                other.SetActive(false);
            }
            i++;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        Interactable m_Interactable = GetComponent<Interactable>();
        ParticleSystem m_ParticleSystem = GetComponentInChildren<ParticleSystem>() as ParticleSystem;

        // Is the fire extinguisher being held?
        if (m_Interactable.m_ActiveHand)
        {
            // Object is being held, we can now determine if we should be
            // activating the fire extinguisher.
            SteamVR_Behaviour_Pose m_Pose = m_Interactable.m_ActiveHand.GetComponent<SteamVR_Behaviour_Pose>();

            // Button pressed down
            if (m_ActivateAction.GetStateDown(m_Pose.inputSource))
            {
                lastFrameOn = true;
                // If down, emit particles
                print("Button down");
                if (m_ParticleSystem.isStopped)
                {
                    m_ParticleSystem.Play(true);
                    RaycastHit extinguisherRay;
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out extinguisherRay, 1, 9))
                    {
                        /*Fire fire = extinguisherRay.collider.GetComponentInParent<Fire>();
                        fire.Extinguish();*/

                    }
                }
            }

            // Button not pressed
            if (m_ActivateAction.GetStateUp(m_Pose.inputSource))
            {
                if (lastFrameOn)
                {
                    print("Button released");
                    lastFrameOn = false;
                    if (m_ParticleSystem.isPlaying)
                    {
                        m_ParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                    }
                }
                // If up, no particles emitted
            }
        }
	}
}
