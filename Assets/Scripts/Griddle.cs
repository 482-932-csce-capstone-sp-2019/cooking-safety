using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Griddle : MonoBehaviour {

    private bool griddle_on = false;
    public List<Cookable> Cookables = new List<Cookable>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TurnOn()
    {
        griddle_on = true;
        foreach (Cookable cook in Cookables)
        {
            cook.on_griddle = true;
        }
    }

    public void TurnOff()
    {
        griddle_on = false;
        foreach (Cookable cook in Cookables)
        {
            cook.on_griddle = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Cookable obj = other.gameObject.GetComponent<Cookable>();
        if (!obj)
        {
            return;
        }
        Cookables.Add(obj);

        if(griddle_on)
        {
            obj.on_griddle = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Cookable obj = other.gameObject.GetComponent<Cookable>();
        if (!obj)
        {
            return;
        }
        Cookables.Remove(obj);
        obj.on_griddle = false;
    }
}
