using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStarter : MonoBehaviour {

	private Fire fire;
    private float start_time;
	private bool started = false;
	// Use this for initialization
	void Awake () {
		fire = GetComponentInChildren<Fire>();
		fire.gameObject.SetActive(false);
        // Create random time for fire to start
        System.Random rand = new System.Random();
        start_time = (float) (rand.NextDouble() * 10) + 5f;
        print("Fire start time will be in " + start_time.ToString() + " seconds");
	}
	
	// Update is called once per frame
	void Update () {
		// Check if fire should start
        if(!started && start_time < Time.timeSinceLevelLoad)
        {
            start_fire();
        }
	}
	
	private void start_fire()
	{
		fire.gameObject.SetActive(true);
		started = true;
	}
}
