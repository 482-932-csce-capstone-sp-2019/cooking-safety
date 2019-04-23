using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Results{

    public static List<KeyValuePair<string, bool>> reasons = new List<KeyValuePair<string, bool>>();

    public static void add(string s, bool b)
    {
        // bool b is false for a bad result/failure
        reasons.Add(new KeyValuePair<string, bool>(s, b));
    }
    
	public static void Fail(string reason)
	{
		Results.reasons.Add(new KeyValuePair<string, bool>(reason, false));
		GameObject.Find("SendToResults").GetComponent<LoadScene>().Load();
	}

    public static void Fail(string reason, int n)
    {
        Results.reasons.Add(new KeyValuePair<string, bool>(reason, false));
    }

    public static void Pass(string reason)
    {
        Results.reasons.Add(new KeyValuePair<string, bool>(reason, true));
        GameObject.Find("SendToResults").GetComponent<LoadScene>().Load();
    }

    public static void Pass(string reason, int n)
    {
        Results.reasons.Add(new KeyValuePair<string, bool>(reason, true));
    }
}
