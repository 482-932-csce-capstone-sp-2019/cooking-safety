using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermometer : MonoBehaviour {

	public float temperature = 72;
    Cookable cook;
	Renderer rend;
	
	void Start () {
		
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		
		//StartCoroutine(Cool());
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Meat")
		{
			cook = col.gameObject.GetComponent<Cookable>();
			
			float otherTemp = cook.core_temp;
			
			for(int i=0;i<otherTemp;i+=5)
			{
				temperature += i;
			}
		}
		StartCoroutine("Heat");
	}
	void OnTriggerExit(Collider col)
	{
		StopCoroutine("Heat");
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
