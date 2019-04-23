using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : Button
{

    protected override void Activate()
    {
        // Load new scene asynchronously
        LoadScene scene_loader = GetComponent<LoadScene>();
        scene_loader.Load();

        // When finished, migrate to new scene
    }

    public void checkCookedTemp()
    {
        GameObject beef_patty = GameObject.Find("beef_patty");
        GameObject chicken_patty = GameObject.Find("chicken_patty");

        var b_patty = beef_patty.GetComponent<Cookable>();
        var c_patty = chicken_patty.GetComponent<Cookable>();

        if (b_patty.core_temp >= 155.0f)
        {
            Results.Pass("Successfully cooked beef patty to proper temperature! PASS.",0);
        }
        else Results.Fail("Beef patty not thorougly cooked. FAIL",0);

        if (c_patty.core_temp >= 165.0f)
        {
            Results.Pass("Successfully cooked chicken patty to proper temperature! PASS.",0);
        }
        else Results.Fail("Chicken patty not thorougly cooked. FAIL",0);
        GameObject.Find("SendToResults").GetComponent<LoadScene>().Load();
        return;
        
    }
}
