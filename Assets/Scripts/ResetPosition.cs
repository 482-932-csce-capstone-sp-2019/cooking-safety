using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Interactable obj = other.gameObject.GetComponent<Interactable>();
        if (obj)
        {
            obj.Reset();
        }
    }
}
