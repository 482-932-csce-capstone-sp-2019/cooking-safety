using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime;

public class ResultsUpdater : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        List<KeyValuePair<string,bool>> reasons = Results.reasons;
        for(int i = 0; i <= reasons.Count; i++)
        {
            if(i >= 6)
            {
                print("More than 6 reasons, update Results scene to support more reasons");
                break;
            }
            string name = "Results" + i.ToString();
            TextMeshPro display = GameObject.Find(name).GetComponent<TextMeshPro>();
			
            if (reasons[i].Value)
            {
                display.color = new Color32(0, 255, 0, 255);
            }
            else display.color = new Color32(255, 0, 0, 255);
            display.text = reasons[i].Key;
        }
	}
}
