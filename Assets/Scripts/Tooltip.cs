using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour {

  public const float AnimateWaitTime = 0.02f;
  private float AnimateWait = 0.02f;
  public const float rotate_speed = 1f;
  public const float grow_speed = 1f;
  private bool wait = false;
  private bool animate_up = false;
  private bool animate_down = false;
  private bool change_scale = false;
  private Quaternion original_rotation;
  private GameObject Tool;
  private GameObject Text;

	void Awake () {
    original_rotation = gameObject.transform.rotation;
    Tool = transform.Find("Cube").gameObject;
    Text = GetComponentInChildren<TextMeshPro>().gameObject;
    Text.SetActive(false);
		Tool.SetActive(false);
	}
	
	public void Show(){
    wait = true;
    if(AnimateWait <= 0){
      StartAnimateUp();
      wait = false;
      AnimateWait = AnimateWaitTime;
    }
  }

  public void Hide(){
    wait = true;
    if(AnimateWait <= 0){
      StartAnimateDown();
      wait = false;
      AnimateWait = AnimateWaitTime;
    }
  }

  void Update() {
    if(wait){
      AnimateWait -= Time.deltaTime;
    }
    if(animate_up){
      AnimateUp();
    }
    if(animate_down){
      AnimateDown();
    }
  }

  private void StartAnimateUp(){
      Tool.SetActive(true);
      Tool.transform.localScale = Vector3.zero;
      animate_up = true;
      change_scale = true;
  }

  private void StartAnimateDown(){
      HideText();
      animate_down = true;
      change_scale = true;
  }

  private void AnimateUp(){
    float grow = grow_speed * Time.deltaTime;
    //grow
    if(Tool.transform.localScale.x < 1.0f){
      Tool.transform.localScale += new Vector3(grow, grow, grow);
    }else{
      change_scale = false;
    }
    //rotate
    if(change_scale || Quaternion.Angle(Tool.transform.rotation, original_rotation) > 2.0f){
      Tool.transform.Rotate(Vector3.up, rotate_speed * Time.deltaTime);
    }else{
      //finish
      ShowText();
      animate_up = false;
    }
  }

  private void AnimateDown(){
    float grow = grow_speed * Time.deltaTime;
    //grow
    if(Tool.transform.localScale.x > 0.0f){
      Tool.transform.localScale -= new Vector3(grow, grow, grow);
    }else{
      change_scale = false;
    }
    //rotate
    if(change_scale){
      transform.Rotate(Vector3.up, rotate_speed * Time.deltaTime);
    }else{
      animate_down = false;
      Tool.SetActive(false);
    }
  }

  private void ShowText(){
    Text.SetActive(true);
  }

  private void HideText(){
    Text.SetActive(false);
  }
}
