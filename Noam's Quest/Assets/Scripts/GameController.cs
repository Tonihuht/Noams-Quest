using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	void Start () {
		
	}

	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Door1") {
			SceneManager.LoadScene ("Tutorial_Fight");
		}
		if (col.gameObject.tag == "JeromeFight") {
			Debug.Log ("Jerome!");
			SceneManager.LoadScene ("FightScreen");
		}
		if (col.gameObject.tag == "Potion") {
			Debug.Log ("AddToInventory");
		}
		if (col.gameObject.tag == "KeyItem") {
			Debug.Log ("AddToKeyItems");
		}
	}
}