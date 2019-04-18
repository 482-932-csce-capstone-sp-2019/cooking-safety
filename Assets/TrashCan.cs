using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : Interactable
{

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
        hand.handState.unglove();
    }
}

