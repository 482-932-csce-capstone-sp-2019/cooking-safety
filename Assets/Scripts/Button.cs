using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
	
    private void OnTriggerEnter(Collider other)
    {
        // If Hand enters collider, activate button
        var hand = other.gameObject.GetComponent<Hand>();
        if (hand)
        {
            // Change color of button for visual feedback
            Renderer renderer = GetComponent<Renderer>();
            Material old_mat = renderer.material;
            GetComponent<Renderer>().material = Resources.Load("ButtonPressed", typeof(Material)) as Material;
            Activate();
            renderer.material = old_mat;
        }

    }

    protected virtual void Activate()
    {
        // Should overrite in a child class
        print("Activate not overridden");
    }
}
