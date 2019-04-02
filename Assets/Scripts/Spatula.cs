using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spatula : Interactable {

    public float x = 0f;
    public float y = 0f;
    public float z = 0.12f;


    public override void Pickup(Hand hand)
    {
        // If already held
        if (m_ActiveHand)
        {
            Drop(hand);
        }

        // Position
        Transform handPosition = hand.gameObject.transform;
        transform.position = handPosition.position + handPosition.TransformDirection(new Vector3(x, y, z));
        print("New transform");
        hand.Attach(this);

        // Set active hand
        m_ActiveHand = hand;
    }

}
