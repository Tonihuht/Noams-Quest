using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleMenuNavigation : MonoBehaviour {


	public void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Debug.Log ("Attack");
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			Debug.Log ("Block");
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			Debug.Log ("Dodge");
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			Debug.Log ("Inventory");
		}
	}
}
