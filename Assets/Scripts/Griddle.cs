using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Griddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Cookable obj = other.gameObject.GetComponent<Cookable>();
        if(obj != null)
        {
            obj.on_griddle = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Cookable obj = other.gameObject.GetComponent<Cookable>();
        if (obj != null)
        {
            obj.on_griddle = false;
        }
    }
}
