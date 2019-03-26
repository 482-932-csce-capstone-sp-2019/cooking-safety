using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Interactable : MonoBehaviour {

    [HideInInspector]
    public Hand m_ActiveHand = null;

    public void Touched(Hand hand)
    {
        Pickup(hand);
    }

    public void Untouched(Hand hand)
    {
        Drop(hand);
    }

    public void Poked(Hand hand)
    {
        //Do nothing normally
    }

    public void Pickup(Hand hand)
    {
        // If already held
        if (m_ActiveHand)
        {
            Drop(hand);
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
