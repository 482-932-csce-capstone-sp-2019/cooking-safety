using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Griddle : MonoBehaviour {

    public bool griddle_on = false;
	bool m_play = false;
	bool toggleChange;
	AudioSource aud;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Cookable obj = other.gameObject.GetComponent<Cookable>();
        if(obj != null && griddle_on)
        {
            obj.on_griddle = true;
			aud = GetComponentInChildren<AudioSource>(); 
			
			if (m_play == true && toggleChange == true)
			{
				//Play the audio you attach to the AudioSource component
				aud.Play();
				//Ensure audio doesn’t play more than once
				toggleChange = false;
			}
			//Check if you just set the toggle to false
			if (m_play == false && toggleChange == true)
			{
				//Stop the audio
				aud.Stop();
				//Ensure audio doesn’t play more than once
				toggleChange = false;
			}
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Cookable obj = other.gameObject.GetComponent<Cookable>();
        if (obj != null && griddle_on)
        {
            obj.on_griddle = false;
        }
    }
}
