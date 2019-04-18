using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Griddle : MonoBehaviour {

    
	bool m_play = false;
	bool toggleChange;
	AudioSource aud;

    private bool griddle_on = false;
    public List<Cookable> Cookables = new List<Cookable>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TurnOn()
    {
        griddle_on = true;
        foreach (Cookable cook in Cookables)
        {
            cook.on_griddle = true;
        }
    }

    public void TurnOff()
    {
        griddle_on = false;
        foreach (Cookable cook in Cookables)
        {
            cook.on_griddle = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Cookable obj = other.gameObject.GetComponent<Cookable>();
        if (!obj)
        {
            return;
        }
        Cookables.Add(obj);

        if(griddle_on)
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
        if (!obj)
        {
            return;
        }
        Cookables.Remove(obj);
        obj.on_griddle = false;
    }
}
