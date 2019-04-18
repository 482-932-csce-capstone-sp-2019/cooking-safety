using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Results{

    public static List<string> reasons = new List<string>();
    
	public static void Fail(string reason)
	{
		Results.reasons.Add(reason);
		GameObject.Find("SendToResults").GetComponent<LoadScene>().Load();
	}
		
}
