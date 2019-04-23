using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Thermometer : MonoBehaviour {

	public enum State {None, Beef, Chicken};
    TextMeshPro display;
	public State last_touched;
	
    void Start()
    {
        display = transform.parent.gameObject.GetComponentInChildren<TextMeshPro>();
    }
	
	State ConvertToState(Meat.Meats m){
		switch(m){
			case Meat.Meats.Beef:
				return State.Beef;
			case Meat.Meats.Chicken:
				return State.Chicken;
			default:
				return State.None;
		}
	}
	
	void OnTriggerEnter(Collider col)
	{
        Cookable cook = col.gameObject.GetComponent<Cookable>();

        if (cook)
		{
			
			// Cross contamination check
			State s = ConvertToState(cook.gameObject.GetComponent<Meat>().my_meat);
            if (last_touched != State.None && s != last_touched)
            {
                Results.Fail("Cross contamination from thermometer. Must wash between different meats. FAIL");
            }
            else
            {
                last_touched = ConvertToState(cook.gameObject.GetComponent<Meat>().my_meat);
                int temperature = (int)cook.core_temp;
                display.text = System.Convert.ToString(temperature);
            }

        }
	}
}
