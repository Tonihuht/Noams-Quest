using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasToggler : MonoBehaviour {
	public Canvas CanvasObject;
	// Use this for initialization
	void Start () {
		CanvasObject = GetComponent<Canvas> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			CanvasObject.enabled = !CanvasObject.enabled;
		}
	}
	public void ToggleCanvas () {
		CanvasObject.enabled = !CanvasObject.enabled;
	}
}
