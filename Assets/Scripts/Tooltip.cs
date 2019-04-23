using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour {

  public const float AnimateWaitTime = 0.02f;
  private float AnimateWait = 0.02f;
  public const float rotate_speed = 180f;
  public const float grow_speed = 1f;
  private bool wait = false;
  private bool hide = false;
  private bool show = false;
  private bool animate_up = false;
  private bool animate_down = false;
  private bool change_scale = false;
  private Quaternion original_rotation;
  private Vector3 original_scale;
  private GameObject Tool;
  private GameObject Text;
  private bool shown = false;

	void Awake () {
        Tool = transform.Find("Cube").gameObject;
        original_rotation = Tool.transform.rotation;
        original_scale = Tool.transform.localScale;
        Text = GetComponentInChildren<TextMeshPro>().gameObject;
        Text.SetActive(false);
		Tool.SetActive(false);
	}
	
	public void Show(){
		if(shown) return;
    wait = true;
    show = true;
  }

  public void Hide(){
        //Tool.SetActive(false);
        //HideText();
  }

  void Update() {
    if(wait){
      AnimateWait -= Time.deltaTime;
    }
    if(animate_up){
      AnimateUp();
    }
    if (AnimateWait <= 0.0f) {
            if (show)
            {
                StartAnimateUp();
            }
    }
  }

  private void StartAnimateUp()
    {
        show = false;
        wait = false;
        AnimateWait = AnimateWaitTime;
        print("Start Animate");
      Tool.SetActive(true);
      Tool.transform.localScale = Vector3.zero;
        Tool.transform.rotation = original_rotation;
      animate_up = true;
      change_scale = true;
  }

  private void AnimateUp(){
    //grow
    if(Tool.transform.localScale.x < original_scale.x){
      Tool.transform.localScale += original_scale * grow_speed * Time.deltaTime;
    }else{
      change_scale = false;
    }
    //rotate
    if (change_scale){
      Tool.transform.Rotate(Vector3.up, rotate_speed * Time.deltaTime);
    }else{
      //finish
      ShowText();
      animate_up = false;
	  shown = true;
    }
  }

  private void ShowText(){
    Text.SetActive(true);
  }

  private void HideText(){
    Text.SetActive(false);
  }
}
