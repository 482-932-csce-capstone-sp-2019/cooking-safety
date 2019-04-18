using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : Snapping {
    public override void Touched(Hand hand)
    {
        Touch_Bread(hand);
        base.Touched(hand);
    }

    private void Touch_Bread(Hand hand)
    {
        hand.handState.touch_bread();
    }
}
