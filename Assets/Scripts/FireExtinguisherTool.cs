using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherTool : Tool {

	private bool pin_pulled = false;
	private Pin pin;
	public void Awake(){
		pin = GetComponentInChildren<Pin>();
	}
	
	public override void Touched(Hand hand)
    {
        // If already held
        if (m_ActiveHand && !pin_pulled)
        {
			pin_pulled = true;
			pin.Touched(hand);
        } else {
			base.Touched(hand);
		}
    }
}
