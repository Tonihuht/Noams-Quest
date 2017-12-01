using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
	//Instantiates variables the player uses
	public int playerSpeed = 5;
	private float moveX;
	private float moveY;
	public bool facingLeft = false;
	public GameDataController controller;

	// Update is called once per frame
	void Update ()
	{
		PlayerMoves ();
	}

	/// <summary>
	/// Creates the method needed for moving the player around.
	/// </summary>
	public void PlayerMoves ()
	{
		//Controls for the player
		moveX = Input.GetAxis ("Horizontal");
		moveY = Input.GetAxis ("Vertical");
		//Turning the player around
		if (moveX < 0.0f && facingLeft == false) {
			FlipPlayer ();
		} else if (moveX > 0.0f && facingLeft == true) {
			FlipPlayer ();
		}
		//Physics for the player
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * playerSpeed, moveY * playerSpeed);
	}

	public void FlipPlayer ()
	{
		facingLeft = !facingLeft;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D col)
	{
		
		if (col.gameObject.tag == "Door1") {
			SceneManager.LoadScene ("Tutorial1");
		}
		if (col.gameObject.tag == "JeromeFight") {
			Debug.Log (GameObject.Find ("jeromeCounter").GetComponent<GameDataController> ().jeromeCounter);
			GameObject.Find ("jeromeCounter").GetComponent<GameDataController> ().jeromeCounter++;
			Debug.Log (GameObject.Find ("jeromeCounter").GetComponent<GameDataController> ().jeromeCounter);
			if (GameObject.Find ("jeromeCounter").GetComponent<GameDataController> ().jeromeCounter < 2) {
				SceneManager.LoadScene ("FightScreen");
			} else {
				Destroy (col.gameObject);
			}
		}
			PlayerPrefs.SetInt ("TutorialAfterFight", SceneManager.GetActiveScene ().buildIndex);

				
		if (col.gameObject.tag == "Potion") {
			Debug.Log ("AddToInventory");
		}
		if (col.gameObject.tag == "KeyItem") {
			Debug.Log ("AddToKeyItems");
		}
		if (col.gameObject.tag == "Item") {
			Inventory.current.AddItem (col.gameObject.GetComponent<Item> ());
			Destroy (col.gameObject);
		}
	}
}


