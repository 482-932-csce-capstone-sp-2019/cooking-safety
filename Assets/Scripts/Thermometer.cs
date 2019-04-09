using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermometer : MonoBehaviour {

	public float temperature = 72;
    Cookable cook;
	Renderer rend;
	
	void Start () {
		
		//StartCoroutine(Cool());
	}
	
	void OnTriggerEnter(Collider col)
	{
        print("Thermometer");
        cook = col.gameObject.GetComponent<Cookable>();

        if (cook)
		{
            print("Meat found");
			
			/*

			float otherTemp = cook.core_temp;
			for(int i=0;i<otherTemp;i+=5)
			{
				temperature += i;
			}
            */
            //StartCoroutine("Heat");
            print(cook.core_temp);
            temperature = cook.core_temp;
        }
	}
	void OnTriggerExit(Collider col)
	{
        if (col.gameObject.GetComponent<Cookable>())
        {
            //StopCoroutine("Heat");
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
            temperature = otherTemp;
        }
	}
	IEnumerator Cool()
	{
		while(true)
		{
            //yield return new WaitForSeconds(5);
            //temperature -= 1;
            float otherTemp = cook.core_temp;
            temperature = otherTemp;
        }
	}
}
