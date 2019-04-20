using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookable : MonoBehaviour {

    // Start at room temperature, later change to freezer temperature?
    public float core_temp = 35.0f;
    private float start_temp;
	
    [HideInInspector]
    public bool on_griddle = false;
	
	private Color startColor;
	private Color endColor;
	//private bool repeatable = false;
	
    public int goalTemp = 250;
	
	Material mat;
	
	// Use this for initialization
	void Start () {

        //startTime = Time.time;
        start_temp = core_temp;
		mat = this.GetComponent<MeshRenderer>().material;
		startColor = mat.color;
		endColor = mat.color * .5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (on_griddle)
        {
            // Adjust this increment operation to change speed that food is cooked
			core_temp += 0.05f;
			float t = (core_temp - start_temp) / (goalTemp - start_temp);
			GetComponent<Renderer>().material.color = Color.Lerp(startColor,endColor,t);
			
			// time += 0.05f;
		}
			
			
			
			// if you want cookable to turn lighter again
			/*
			if(repeatable)
			{
				float t = (Mathf.Sin(Time.time - startTime)*(core_temp/100.0f));
				GetComponent<Renderer>().material.color = Color.Lerp(startColor,endColor,t);
			}
			*/
		
	}
	
}
