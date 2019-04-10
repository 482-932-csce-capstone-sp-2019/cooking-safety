using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Thermometer : MonoBehaviour {

	public float temperature = 0;
    Cookable cook;
	Renderer rend;
    TextMeshPro display;
	
    void Start()
    {
        display = transform.parent.gameObject.GetComponentInChildren<TextMeshPro>();
    }

	void Update()
    {
        display.text = System.Convert.ToString(temperature);
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
