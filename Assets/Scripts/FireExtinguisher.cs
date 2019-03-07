using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FireExtinguisher : MonoBehaviour {

    public SteamVR_Action_Boolean m_ActivateAction = null;

    // Use this for initialization
    void Awake ()
    {
    }

    // Update is called once per frame
    void Update ()
    {
        Interactable m_Interactable = GetComponent<Interactable>();

        // Is the fire extinguisher being held?
        if (m_Interactable.m_ActiveHand)
        {
            // Object is being held, we can now determine if we should be
            // activating the fire extinguisher.
            SteamVR_Behaviour_Pose m_Pose = m_Interactable.m_ActiveHand.GetComponent<SteamVR_Behaviour_Pose>();
            
            // Button pressed down
            if (m_ActivateAction.GetStateDown(m_Pose.inputSource))
            {
                // If down, emit particles
                print("Button down");
            }

            // Button not pressed
            if (m_ActivateAction.GetStateUp(m_Pose.inputSource))
            {
                // If up, no particles emmitted
            }
        }
	}
}
