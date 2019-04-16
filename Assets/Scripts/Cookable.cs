using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookable : MonoBehaviour {

    // Start at room temperature, later change to freezer temperature?
    public float core_temp = 35.0f;
	
	
    public bool on_griddle = false;
	
	public Color startColor;
	public Color endColor;
	public bool repeatable = false;
	
	public float time = 0.0f;
	
	Material mat;
	
	// Use this for initialization
	void Start () {
		
		//startTime = Time.time;
		mat = this.GetComponent<MeshRenderer>().material;
		startColor = mat.color;
		endColor = mat.color * .5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (on_griddle)
        {
			core_temp += 0.00005f;
			float t = (time)*(core_temp);
			GetComponent<Renderer>().material.color = Color.Lerp(startColor,endColor,t);
			
			time += 0.00001f;
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
