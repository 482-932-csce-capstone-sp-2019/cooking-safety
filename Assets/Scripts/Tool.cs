using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : Interactable {



    public override void Pickup(Hand hand)
    {
        // If already held
        if (m_ActiveHand)
        {
            Drop(hand);
        }

        // Position

        transform.localPosition = hand.transform.position - transform.Find("InteractionPoint").localPosition;
        transform.localRotation = Quaternion.Inverse(transform.Find("InteractionPoint").localRotation);

        var renderer = hand.GetComponentInChildren<SkinnedMeshRenderer>();
        renderer.enabled = false;
        hand.Attach(this);

        // Set active hand
        m_ActiveHand = hand;
    }

    public override void Drop(Hand hand)
    {
        hand.copyVelocity(this);

        var renderer = hand.GetComponentInChildren<SkinnedMeshRenderer>();
        renderer.enabled = true;
        // Detach
        hand.Detach();

        // Clear
        m_ActiveHand = null;
    }

}


