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
			SceneManager.LoadScene ("Tutorial1");
		}
		if (col.gameObject.tag == "JeromeFight") {
			Destroy (col.gameObject);
			Debug.Log ("Destroy");
			SceneManager.LoadScene ("FightScreen"); 
			Debug.Log ("Jerome!");
		}
		if (col.gameObject.tag == "Potion") {
			Debug.Log ("AddToInventory");
		}
		if (col.gameObject.tag == "KeyItem") {
			Debug.Log ("AddToKeyItems");
		}
	}
}