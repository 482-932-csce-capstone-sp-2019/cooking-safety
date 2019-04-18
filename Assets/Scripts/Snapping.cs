using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Snapping : Interactable {

    private SnapPoint snapPoint = null; 
	private FixedJoint m_joint;
    public Snapping CurrentSnapping = null;

    public override void Touched(Hand hand)
    {
        Unsnap();
        base.Touched(hand);
    }

    public override void Untouched(Hand hand)
    {
        base.Untouched(hand);
        Snap();
    }

    public override void Poked(Hand hand)
    {
        //Do nothing normally
    }

    void Snap()
    {
        CurrentSnapping = snapPoint.GetNearestSnapping();

        if (!CurrentSnapping){ return; }
		CurrentSnapping.GetSnapPoint().DisableHighlighting();
		MoveToSnapPoint();
		m_joint = gameObject.AddComponent<FixedJoint>();
		m_joint.connectedBody = CurrentSnapping.gameObject.GetComponent<Rigidbody>();
    }

    void Unsnap()
    {
        if(!CurrentSnapping){ return; }
		
		m_joint.connectedBody = null;
		Destroy(m_joint);
		
		CurrentSnapping.GetSnapPoint().EnableHighlighting();
		
        CurrentSnapping = null;
    }

    // Use this for initialization
    private void Awake()
    {
        snapPoint = GetComponentInChildren<SnapPoint>();
    }
	

    public SnapPoint GetSnapPoint(){
        return snapPoint;
    }
	
	private void MoveToSnapPoint()
	{
		transform.position = CurrentSnapping.GetSnapPoint().gameObject.transform.position;
		transform.rotation = CurrentSnapping.GetSnapPoint().gameObject.transform.rotation;
	}
}
