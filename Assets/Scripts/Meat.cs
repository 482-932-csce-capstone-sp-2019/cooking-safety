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

    void OnCollisionEnter(Collision col)
    {
        Meat other = col.gameObject.GetComponent<Meat>();
        if (other)
        {
            // Check if ours is chicken so failure is only called once instead of twice
            if (my_meat == Meats.Chicken && my_meat != other.my_meat)
            {
                // Fail for cross contamination of meats
                Results.Fail("Cross contamination between Chicken and Beef. FAIL");
            }
        }
    }
}
