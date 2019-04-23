using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GloveBox : Interactable {

    public override void Touched(Hand hand)
    {
        //Do Nothing
    }

    public override void Untouched(Hand hand)
    {
        //Do Nothing
    }

    public override void Poked(Hand hand)
    {
		print(hand.handState.to_s());
        hand.handState.glove();
    }
}
