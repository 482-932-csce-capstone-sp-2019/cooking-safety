using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GloveBox : Interactable {

    public void Touched(Hand hand)
    {
        //Do Nothing
    }

    public void Untouched(Hand hand)
    {
        //Do Nothing
    }

    public void Poked(Hand hand)
    {
        hand.handState.glove();
    }
}
