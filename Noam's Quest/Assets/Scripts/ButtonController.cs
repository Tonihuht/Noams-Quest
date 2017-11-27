using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public bool buttonPressed;

	public bool GetButtonPressed () {
		return this.buttonPressed;
	}

	public void OnPointerDown (PointerEventData eventData) {
		//Debug.Log (eventData);
		this.buttonPressed = true;
	}

	public void OnPointerUp (PointerEventData eventData) {
		//Debug.Log (eventData);
		this.buttonPressed = false;
	}
}
