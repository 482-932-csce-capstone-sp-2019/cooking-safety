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
        float tilt_x;
        float tilt_y;
        if (griddle_on)
        {
            tilt_x = 62f;
            tilt_y = 0f;
            griddle_on = false;
        }
        else
        {
            tilt_x = -62f;
            tilt_y = 180f;
            griddle_on = true;
        }

        transform.localRotation = Quaternion.Euler(tilt_x, tilt_y, 0);

        // Tell Griddle.cs to reflect the changes
        if(griddle_on)
        {
            GameObject.Find("GriddleLogic").GetComponent<Griddle>().TurnOn();
        }
        else
        {
            GameObject.Find("GriddleLogic").GetComponent<Griddle>().TurnOff();
        }
    }
}
