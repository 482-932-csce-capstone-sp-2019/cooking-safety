using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultsUpdater : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        List<string> reasons = Results.reasons;
        for(int i = 1; i <= reasons.Count; i++)
        {
            if(i > 7)
            {
                print("More than 6 reasons, update Results scene to support more reasons");
                break;
            }
            string name = "Results" + i.ToString();
            TextMeshPro display = GameObject.Find(name).GetComponent<TextMeshPro>();
            display.text = reasons[i];
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
