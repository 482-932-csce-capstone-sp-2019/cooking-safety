using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : Snapping {

	public enum Meats {Beef, Chicken};
	public Meats my_meat;
	
	public override void Touched(Hand hand)
    {
		Touch_Meat(hand);
        base.Touched(hand);
    }
	
	private void Touch_Meat(Hand hand)
	{
		if(my_meat == Meats.Beef)
		{
			hand.handState.touch_beef();	
		}
		if(my_meat == Meats.Chicken)
		{
			hand.handState.touch_chicken();
		}
	}
}
