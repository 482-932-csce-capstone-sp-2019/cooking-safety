using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {


	public Material[] material;
	Renderer rend;
	
	// Use this for initialization
	void Start () {
		
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		rend.sharedMaterial = material[0];
		
	}
	
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Pink")
		{
			rend.sharedMaterial = material[1];
		}
	}
}
