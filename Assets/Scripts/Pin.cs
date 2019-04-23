using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : Interactable {

	public override void Touched(Hand hand)
	{
		GetComponent<Rigidbody>().isKinematic = false;
		base.Touched(hand);
	}
}
