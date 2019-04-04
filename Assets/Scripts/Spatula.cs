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

        /*
        Transform handTransform = hand.gameObject.transform;
        transform.position = handTransform.position + handTransform.TransformDirection(new Vector3(x, y, z));
        Vector3 angles = new Vector3(handTransform.eulerAngles.x, handTransform.eulerAngles.y, handTransform.eulerAngles.z);
        transform.eulerAngles = angles;
        print("New transform");
        */

        print("Old transform: " + transform.position.x + " " + transform.position.y + " " + transform.position.z);
        print("Old local transform: " + transform.localPosition.x + " " + transform.localPosition.y + " " + transform.localPosition.z);


        transform.localPosition = hand.transform.position - transform.Find("InteractionPoint").localPosition;
        transform.localRotation = Quaternion.Inverse(transform.Find("InteractionPoint").localRotation);
        print("New transform: " + transform.position.x + " " + transform.position.y + " " + transform.position.z);
        print("New local transform: " + transform.localPosition.x + " " + transform.localPosition.y + " " + transform.localPosition.z);

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


