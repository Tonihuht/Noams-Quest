﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleCanvas : MonoBehaviour {

	private CanvasScaler scaler;
	// Use this for initialization
	void Start () {
		//Automatically scales the canvas to the right size
		scaler = GetComponent<CanvasScaler>();
		scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
	}
}
