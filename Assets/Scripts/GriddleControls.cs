using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GriddleControls : Interactable {

    private bool griddle_on;

	// Use this for initialization
	void Start () {
        griddle_on = false;
	}

    public override void Touched(Hand hand)
    {
        //Do Nothing
    }

    public override void Untouched(Hand hand)
    {
        //Do Nothing
    }

    public override void Poked(Hand hand)
    {
        // Turn the control's rotation when poked
        float tilt_x = transform.rotation.x * -1;
        float tilt_y;
        if (griddle_on)
        {
            tilt_y = 0f;
            griddle_on = false;
        }
        else
        {
            tilt_y = 180f;
            griddle_on = true;
        }
        Quaternion target = Quaternion.Euler(tilt_x, tilt_y, 0);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5.0f);

        // Tell Griddle.cs to reflect the changes
        GameObject.Find("GriddleLogic").GetComponent<Griddle>().griddle_on = griddle_on;
    }
}
