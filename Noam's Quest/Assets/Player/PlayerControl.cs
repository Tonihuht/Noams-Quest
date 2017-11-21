using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public int playerSpeed = 10;
	private float moveX;
	private float moveY;

	
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
}
