using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipCollider : MonoBehaviour {
    public void OnTriggerEnter(Collider collider)
    {
      var tool = collider.gameObject.GetComponent<Tooltip>();
      if(!tool) return;
      tool.Show();
    }

    public void OnTriggerExit(Collider collider)
    {
      var tool = collider.gameObject.GetComponent<Tooltip>();
      if(!tool) return;
      tool.Hide();
    }
}
