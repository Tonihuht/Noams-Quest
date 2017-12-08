using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleCanvas : MonoBehaviour
{
	//Creates the variables needed for the invetorys canvas scaling
	private CanvasScaler scaler;
	// Use this for initialization
	void Start ()
	{
//		if (FindObjectsOfType<HandleCanvas>().Length > 2) {
//			Destroy(gameObject);
//		}
		//Automatically scales the canvas to the right size
		scaler = GetComponent<CanvasScaler> ();
		scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
	}
}
