using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class SnapPoint : MonoBehaviour
{
	private Snapping parentSnapping;
	private bool highlightingEnabled = true;
    public List<Snapping> CurrentSnappings = new List<Snapping>();
	private List<Snapping> InTrigger = new List<Snapping>();

	private void Awake()
	{
		parentSnapping = GetComponentInParent<Snapping>();
	}
	
    private void OnTriggerEnter(Collider other)
    {
        Snapping otherSnapping = other.gameObject.GetComponent<Snapping>();
        if (!otherSnapping || otherSnapping == parentSnapping || otherSnapping == parentSnapping.CurrentSnapping)
        {
            return;
        }
        otherSnapping.GetSnapPoint().CurrentSnappings.Add(this.parentSnapping);
		InTrigger.Add(otherSnapping);
		ShowSnapHighlight();
    }

    private void OnTriggerExit(Collider other)
    {
        Snapping otherSnapping = other.gameObject.GetComponent<Snapping>();
        if (!otherSnapping)
        {
            return;
        }
        otherSnapping.GetSnapPoint().CurrentSnappings.Remove(this.parentSnapping);
		InTrigger.Remove(otherSnapping);
		HideSnapHighlight();
    }

    public Snapping GetNearestSnapping()
    {
        Snapping nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;
        foreach (Snapping snapping in CurrentSnappings)
        {
            if (snapping != GetComponentInParent<Snapping>())
            {
                distance = (snapping.transform.position - transform.position).sqrMagnitude;
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = snapping;
                }
            }
        }

        return nearest;
    }
	
	public void DisableHighlighting()
	{
		HideSnapHighlight();
		highlightingEnabled = false;
	}
	
	public void EnableHighlighting()
	{
		highlightingEnabled = true;
		if(InTrigger.Count > 0){
			ShowSnapHighlight();
		}
	}
	
	private void HideSnapHighlight()
	{
		if(!highlightingEnabled) return;
		transform.GetChild(0).gameObject.SetActive(false);
	}
	
	private void ShowSnapHighlight()
	{		
		if(!highlightingEnabled) return;
		transform.GetChild(0).gameObject.SetActive(true);
	}
		
}
