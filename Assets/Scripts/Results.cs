using System.Collections;
using System.Collections.Generic;

public static class Results{

    public static List<KeyValuePair<string, bool>> reasons = new List<KeyValuePair<string, bool>();

    public static void add(string s, bool b)
    {
        // bool b is false for a bad result/failure
        reasons.Add(new KeyValuePair<string, bool>(s, b));
    }
    
}
