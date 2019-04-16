using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(FixedJoint))]
[RequireComponent(typeof(BoxCollider))]
public class SnapPoint : MonoBehaviour
{
    private FixedJoint m_Joint = null;
    public List<Snapping> CurrentSnappings = new List<Snapping>();

    public void Awake()
    {
        m_Joint = GetComponent<FixedJoint>();
    }

    public void Attach(Snapping snapping)
    {
        // Attach
        print(snapping);
        Rigidbody targetBody = snapping.GetComponent<Rigidbody>();
        m_Joint.connectedBody = targetBody;
    }

    public void Detach()
    {
        m_Joint.connectedBody = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        Snapping otherSnapping = other.gameObject.GetComponent<Snapping>();
        if (!otherSnapping)
        {
            return;
        }
        CurrentSnappings.Add(otherSnapping);
    }

    private void OnTriggerExit(Collider other)
    {
        Snapping otherSnapping = other.gameObject.GetComponent<Snapping>();
        if (!otherSnapping)
        {
            return;
        }
        CurrentSnappings.Remove(otherSnapping);
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
}
