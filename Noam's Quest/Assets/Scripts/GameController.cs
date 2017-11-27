using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	private ButtonController bLeft;
	private ButtonController bRight;
	private ButtonController bUp;
	private ButtonController bDown;
	private GameObject player;
	public float speed = 0.1f;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		bLeft = GameObject.Find ("ButtonLeft").GetComponent<ButtonController> ();
		bRight = GameObject.Find ("ButtonRight").GetComponent<ButtonController> ();
		bUp = GameObject.Find ("ButtonUp").GetComponent<ButtonController> ();
		bDown = GameObject.Find ("ButtonDown").GetComponent<ButtonController> ();
	}

	void Update () {
		if (bLeft.GetButtonPressed ()) {
			//Debug.Log ("Moving left");
			player.transform.Translate(-1 * speed, 0, 0);
		}
		if (bRight.GetButtonPressed ()) {
			//Debug.Log ("Moving right");
			player.transform.Translate(1 * speed, 0, 0);
		}
		if (bUp.GetButtonPressed ()) {
			//Debug.Log ("Moving left");
			player.transform.Translate(0, 1 * speed, 0);
		}
		if (bDown.GetButtonPressed ()) {
			//Debug.Log ("Moving left");
			player.transform.Translate(0, -1 * speed, 0);
		}

	}

	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D col)
	{
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