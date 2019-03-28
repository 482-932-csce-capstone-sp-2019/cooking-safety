using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookable : MonoBehaviour {

    // Start at room temperature, later change to freezer temperature?
    public float core_temp = 72.0f;
    public bool on_griddle = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (on_griddle)
        {
            core_temp += 0.1f;
        }
	}
}
