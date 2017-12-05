using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
		Buttons ();
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
		if (col.gameObject.tag == "Door0") {
			SceneManager.LoadScene ("Tutorial");
		}

		if (col.gameObject.tag == "Door1") {
			SceneManager.LoadScene ("Tutorial1");
		}

		if (col.gameObject.tag == "Door2") {
			SceneManager.LoadScene ("CrollsCastle");
		}

		if (col.gameObject.tag == "Door3") {
			SceneManager.LoadScene ("CrollsCastle2");
		}

		if (col.gameObject.tag == "Door4") {
			SceneManager.LoadScene ("Mountain1");
		}

		if (col.gameObject.tag == "Door5") {
			SceneManager.LoadScene ("Mountain2");
		}

		if (col.gameObject.tag == "Door6") {
			SceneManager.LoadScene ("Bridge");
		}

		if (col.gameObject.tag == "Door7") {
			SceneManager.LoadScene ("DarkForest");
		}

		if (col.gameObject.tag == "Tamara") {
			SceneManager.LoadScene ("TheEnd");
		}

		if (col.gameObject.tag == "MainMenu") {
			SceneManager.LoadScene ("MainMenu");
		}


		if (col.gameObject.tag == "JeromeFight") {
			//GameDataController.SavePosition ();
			Debug.Log (GameObject.Find ("jeromeCounter").GetComponent<GameDataController> ().jeromeCounter);
			GameObject.Find ("jeromeCounter").GetComponent<GameDataController> ().jeromeCounter++;
			Debug.Log (GameObject.Find ("jeromeCounter").GetComponent<GameDataController> ().jeromeCounter);
			if (GameObject.Find ("jeromeCounter").GetComponent<GameDataController> ().jeromeCounter < 2) {
				SceneManager.LoadScene ("FightScreenJerome");
			} else {
				Destroy (col.gameObject);
			}
		}
			PlayerPrefs.SetString ("LastLevel", SceneManager.GetActiveScene ().name);

				
		if (col.gameObject.tag == "Potion") {
			Debug.Log ("AddToInventory");
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag == "KeyItem") {
			Debug.Log ("AddToKeyItems");
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag == "Item") {
			Inventory.current.AddItem (col.gameObject.GetComponent<Item> ());
			Destroy (col.gameObject);
		}
	}
	void Buttons () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("PauseMenu");
		}
	}
}


