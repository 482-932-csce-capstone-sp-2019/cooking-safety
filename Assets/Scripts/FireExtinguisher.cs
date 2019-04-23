using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FireExtinguisher : MonoBehaviour {
    GameObject extinguisher;
	Interactable m_Interactable;
    public SteamVR_Action_Boolean m_ActivateAction = null;
    private bool lastFrameOn = false;
	
    // Use this for initialization
    void Awake ()
    {
        extinguisher = GetComponentInChildren<ParticleSystem>().gameObject;
		extinguisher.gameObject.SetActive(false);
		m_Interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update ()
    {
        // Is the fire extinguisher being held?
        if (!m_Interactable.m_ActiveHand) return;
		
		// Object is being held, we can now determine if we should be
        // activating the fire extinguisher.
        SteamVR_Behaviour_Pose m_Pose = m_Interactable.m_ActiveHand.GetComponent<SteamVR_Behaviour_Pose>();

        // Button pressed down
        if (m_ActivateAction.GetStateDown(m_Pose.inputSource))
        {
            StartExtinguish();
        }

        // Button not pressed
        if (m_ActivateAction.GetStateUp(m_Pose.inputSource))
        {
            StopExtinguish();
        }
	}
	
	private void StartExtinguish()
	{
		lastFrameOn = true;
	    extinguisher.SetActive(true);
	}
	
	private void StopExtinguish()
	{
		if (lastFrameOn)
        {
            lastFrameOn = false;
			extinguisher.SetActive(false);
        }
	}
}
