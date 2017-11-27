using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {

	public int playerSpeed = 10;
	private float moveX;
	private float moveY;
	public Inventory inventory;

	
	// Update is called once per frame
	void Update () {
		PlayerMoves ();
	}

	public void PlayerMoves () {
		//Controls for the player
		moveX = Input.GetAxis ("Horizontal");
		moveY = Input.GetAxis ("Vertical");

		//Physics for the player
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * playerSpeed, moveY * playerSpeed);
	}
	private void OnCollisionEnter2D(Collision2D col) {
		Debug.Log ("This is an item");
		if (col.gameObject.tag == "Item") {
			inventory.AddItem (col.gameObject.GetComponent<Item> ());
			Destroy (col.gameObject);
		}
	}
}


//OnCollisionEnter2D(Collision2D coll)