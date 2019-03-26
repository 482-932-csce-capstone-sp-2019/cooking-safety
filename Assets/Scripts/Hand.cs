using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour
{


    // For picking up and releasing objects
    public SteamVR_Action_Boolean m_GrabAcion = null;

    private SteamVR_Behaviour_Pose m_Pose = null;
    private FixedJoint m_Joint = null;

    private Interactable m_CurrentInteractable = null;
    public List<Interactable> m_ContactInteractables = new List<Interactable>();

	// Use this for initialization
	private void Awake ()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();
	}
	
	// Update is called once per frame
	private void Update ()
    {
        // Down
        if (m_GrabAcion.GetStateDown(m_Pose.inputSource))
        {
            Touch();
        }
        // Up
        if (m_GrabAcion.GetStateUp(m_Pose.inputSource))
        {
            Poke();
            Untouch();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
        {
            return;
        }
        m_ContactInteractables.Add(other.gameObject.GetComponent<Interactable>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
        {
            return;
        }
        m_ContactInteractables.Remove(other.gameObject.GetComponent<Interactable>());
    }

    public void Attach(Interactable interactable)
    {
        // Attach
        Rigidbody targetBody = interactable.GetComponent<Rigidbody>();
        m_Joint.connectedBody = targetBody;
    }

    public void Detach()
    {
        m_Joint.connectedBody = null;
    }

    public void Touch()
    {
        // Get nearest inteactable
        m_CurrentInteractable = GetNearestInteractable();
        
        // Check if null
        if (!m_CurrentInteractable)
        {
            return;
        }

        m_CurrentInteractable.Touched(this);
    }

    public void Untouch()
    {
        // Check if null
        if (!m_CurrentInteractable)
        {
            return;
        }

        m_CurrentInteractable.Untouched(this);
        m_CurrentInteractable = null;
    }

    public void Poke()
    {
        if(!m_CurrentInteractable){
            return;
        }
        if(m_CurrentInteractable == GetNearestInteractable()){
            m_CurrentInteractable.Poked(this);
        }
    }

    public void copyVelocity(Interactable interactable){
        // Apply velocity
        Rigidbody targetBody = interactable.GetComponent<Rigidbody>();
        targetBody.velocity = m_Pose.GetVelocity();
        targetBody.angularVelocity = m_Pose.GetAngularVelocity();
    }

    private Interactable GetNearestInteractable()
    {
        Interactable nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;
        foreach(Interactable interactable in m_ContactInteractables)
        {
            distance = (interactable.transform.position - transform.position).sqrMagnitude;
            if(distance < minDistance)
            {
                minDistance = distance;
                nearest = interactable;
            }
        }

        return nearest;
    }
}
