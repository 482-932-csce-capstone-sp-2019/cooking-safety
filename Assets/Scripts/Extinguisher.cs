using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour {

	private List<Fire> fires = new List<Fire>();
	
	// Update is called once per frame
	void Update () {
		foreach(Fire f in fires){
			f.Extinguish();
		}
	}
	
	private void OnTriggerEnter(Collider other)
    {
        Fire obj = other.gameObject.GetComponent<Fire>();
        if (!obj)
        {
            return;
        }
        fires.Add(obj);
    }

    private void OnTriggerExit(Collider other)
    {
        Fire obj = other.gameObject.GetComponent<Fire>();
        if (!obj)
        {
            return;
        }
        fires.Remove(obj);
    }
}
