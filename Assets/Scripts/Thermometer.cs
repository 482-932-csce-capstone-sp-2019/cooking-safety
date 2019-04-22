using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Thermometer : MonoBehaviour {

	public int temperature = 0;
	public enum State {None, Beef, Chicken};
    Cookable cook;
	Renderer rend;
    TextMeshPro display;
	public State last_touched;
	
    void Start()
    {
        display = transform.parent.gameObject.GetComponentInChildren<TextMeshPro>();
    }

	void Update()
    {
        display.text = System.Convert.ToString(temperature);
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
        cook = col.gameObject.GetComponent<Cookable>();

        if (cook)
		{
			
			/*

			float otherTemp = cook.core_temp;
			for(int i=0;i<otherTemp;i+=5)
			{
				temperature += i;
			}
            */
            //StartCoroutine("Heat");
			
			// Cross contamination check
			State s = ConvertToState(cook.gameObject.GetComponent<Meat>().my_meat);
			if(last_touched != State.None && s != last_touched){
				Results.Fail("Cross contamination from thermometer. Must wash between different meats. FAIL");
			}
			else
				temperature = (int)cook.core_temp;
        }
	}
	void OnTriggerExit(Collider col)
	{
        if (col.gameObject.GetComponent<Cookable>())
        {
            //StopCoroutine("Heat");
			last_touched = ConvertToState(cook.gameObject.GetComponent<Meat>().my_meat);
            cook = null;
        }
	}
	
	IEnumerator Heat()
	{
		while(true)
		{
            //yield return new WaitForSeconds(5);
            //temperature += 1;

            float otherTemp = cook.core_temp;
            temperature = (int)otherTemp;
        }
	}
	IEnumerator Cool()
	{
		while(true)
		{
            //yield return new WaitForSeconds(5);
            //temperature -= 1;
            float otherTemp = cook.core_temp;
            temperature = (int)otherTemp;
        }
	}
}
