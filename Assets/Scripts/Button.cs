using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    private Material inverse_mat;

    private void Start()
    {
        inverse_mat = Resources.Load("ButtonPressed", typeof(Material)) as Material;
    }

    private void SwitchMaterial()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material temp_mat = inverse_mat;
        inverse_mat = renderer.material;
        GetComponent<Renderer>().material = temp_mat;
    }
	
    private void OnTriggerEnter(Collider other)
    {
        // If Hand enters collider, activate button
        var hand = other.gameObject.GetComponent<Hand>();
        if (hand)
        {
            // Change color of button for visual feedback
            SwitchMaterial();
            Activate();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        // If Hand exits collider, change button color back
        var hand = other.gameObject.GetComponent<Hand>();
        if (hand)
        {
            SwitchMaterial();
        }
    }

    protected virtual void Activate()
    {
        // Should overrite in a child class
        print("Activate not overridden");
    }
}
