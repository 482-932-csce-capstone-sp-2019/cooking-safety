using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStarter : MonoBehaviour {

	private Fire fire;
	// Use this for initialization
	void Awake () {
		fire = GetComponentInChildren<Fire>();
		fire.gameObject.SetActive(false);
		//TODO create random time for fire to start
		start_fire(); //TODO remove
	}
	
	// Update is called once per frame
	void Update () {
		//TODO check if fire should start
	}
	
	private void start_fire()
	{
		fire.gameObject.SetActive(true);
	}
}
