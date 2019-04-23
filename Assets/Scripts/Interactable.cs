using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Interactable : MonoBehaviour {

    [HideInInspector]
    public Hand m_ActiveHand = null;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    public void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public void Reset()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    public virtual void Touched(Hand hand)  
    {
        Pickup(hand);
    }

    public virtual void Untouched(Hand hand)
    {
        Drop(hand);
    }

    public virtual void Poked(Hand hand)
    {
        //Do nothing normally
    }

    public void Pickup(Hand hand)
    {
		hand.m_CurrentInteractable = this;
        // If already held
        if (m_ActiveHand)
        {
            Drop(m_ActiveHand);
        }

        // Position
        transform.position = hand.gameObject.transform.position;

        hand.Attach(this);

        // Set active hand
        m_ActiveHand = hand;
    }

    public void Drop(Hand hand)
    {
        hand.copyVelocity(this);

        // Detach
        hand.Detach();

        // Clear
        m_ActiveHand = null;
    }
}
