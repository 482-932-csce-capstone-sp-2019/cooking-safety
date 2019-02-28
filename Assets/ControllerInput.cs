using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;

public class ControllerInput : MonoBehaviour {
    //Should only ever be one, but just in case
    protected List<InteractableItem> heldObjects;

    //Controller References
    protected SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }

    void Awake()
    {
        //Instantiate lists
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        heldObjects = new List<InteractableItem>();
    }


    void Update()
    {
        if (heldObjects.Count > 0)
        {
            //If trigger is releasee
            if (device.GetPressUp(EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                //Release any held objects
                for (int i = 0; i < heldObjects.Count; i++)
                {
                    heldObjects[i].Release(this);
                }
                heldObjects = new List<InteractableItem>();
            }
        }
    }

    void OnTriggerStay(Collider _collider)
    {
        //If object is an interactable item
        InteractableItem interactable = _collider.GetComponent<InteractableItem>();
        if (interactable != null)
        {
            //If trigger button is down
            if (device.GetPressDown(EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                //Pick up object
                interactable.Pickup(this);
                heldObjects.Add(interactable);
            }
        }
    }
}
