using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Interactable obj = other.gameObject.GetComponent<Interactable>();
        if (obj)
        {
            obj.Reset();
        }
    }
}
