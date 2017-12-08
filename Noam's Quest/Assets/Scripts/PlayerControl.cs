using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
	//Instantiates variables the player uses, such as buttons and some booleans
	public int playerSpeed = 5;
	private float moveX;
	private float moveY;
	public bool facingLeft = false;
	public GameDataController controller;
	private ButtonController bLeft;
	private ButtonController bRight;
	private ButtonController bUp;
	private ButtonController bDown;
	private ButtonController zButton;
	private GameObject player;
	public float speed = 0.1f;
	public CanvasToggler canvasT;
	public bool door1 = false;
	public bool bridgeDoor1 = false;
	public bool bridgeDoor2 = false;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		bLeft = GameObject.Find ("LeftArrow").GetComponent<ButtonController> ();
		bRight = GameObject.Find ("RightArrow").GetComponent<ButtonController> ();
		bUp = GameObject.Find ("UpArrow").GetComponent<ButtonController> ();
		bDown = GameObject.Find ("DownArrow").GetComponent<ButtonController> ();
		zButton = GameObject.Find ("ZButton").GetComponent<ButtonController> ();
		canvasT = GameObject.Find ("CanvasButton").GetComponent<CanvasToggler> ();
	}
	// Update is called once per frame
	void Update ()
	{
		if (zButton.GetButtonPressed ()) {
			PlayerPrefs.SetFloat ("PlayerX", player.transform.position.x);
			PlayerPrefs.SetFloat ("PlayerY", player.transform.position.y);
			PlayerPrefs.SetString ("TutorialOut", SceneManager.GetActiveScene ().name);
			PlayerPrefs.Save ();
			print (PlayerPrefs.GetString ("TutorialOut"));
			SceneManager.LoadScene ("PauseMenu");
		}
		if (bLeft.GetButtonPressed ()) {
			//Debug.Log ("Moving left");
			player.transform.Translate(-1f * speed, 0, 0);
			if (facingLeft == false) {
				FlipPlayer ();
			}
		}
		if (bRight.GetButtonPressed ()) {
			//Debug.Log ("Moving right");
			player.transform.Translate (1f * speed, 0, 0);
			if (facingLeft == true) {
				FlipPlayer ();
			}
		}
		if (bUp.GetButtonPressed ()) {
			//Debug.Log ("Moving left");
			player.transform.Translate(0, 1f * speed, 0);
		}
		if (bDown.GetButtonPressed ()) {
			//Debug.Log ("Moving left");
			player.transform.Translate(0, -1f * speed, 0);
		}
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
	/// <summary>
	/// Flips the player.
	/// </summary>
	public void FlipPlayer ()
	{
		facingLeft = !facingLeft;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	/// <summary>
	/// Detects players collisions with other objects
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "BridgeDoor1") {
			if (bridgeDoor1 == true) {
				Destroy (col.gameObject);
			}
		}

		if (col.gameObject.tag == "BridgeDoor2") {
			if (bridgeDoor2 == true) {
				Destroy (col.gameObject);
			}
		}

		if (col.gameObject.tag == "Door0") {
			SceneManager.LoadScene ("Tutorial");
		}

		if (col.gameObject.tag == "Door1") {
			SceneManager.LoadScene ("Tutorial1");
		}

		if (col.gameObject.tag == "Door2") {
			if (door1 == true) {
				SceneManager.LoadScene ("CrollsCastle");
				}
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

		if (col.gameObject.tag == "CrollFight1") {
			GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().crollCounter1++;
			if (GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().crollCounter1 < 2) {
				Time.timeScale = 0;
				PlayerPrefs.SetString ("LastLevel", SceneManager.GetActiveScene ().name);
				SceneManager.LoadSceneAsync ("FightScreenCroll1",LoadSceneMode.Additive);
				canvasT.ToggleCanvas();
			} else {
				Destroy (col.gameObject);
			}
		}

		if (col.gameObject.tag == "CrollFight2") {
			GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().crollCounter2++;
			if (GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().crollCounter2 < 2) {
				Time.timeScale = 0;
				PlayerPrefs.SetString ("LastLevel", SceneManager.GetActiveScene ().name);
				SceneManager.LoadSceneAsync ("FightScreenCroll2",LoadSceneMode.Additive);
				canvasT.ToggleCanvas();
			} else {
				Destroy (col.gameObject);
			}
		}

		if (col.gameObject.tag == "AbraFight1") {
			GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().abraCounter1++;
			if (GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().abraCounter1 < 2) {
				Time.timeScale = 0;
				PlayerPrefs.SetString ("LastLevel", SceneManager.GetActiveScene ().name);
				SceneManager.LoadSceneAsync ("FightScreenAbra1",LoadSceneMode.Additive);
				canvasT.ToggleCanvas();
			} else {
				Destroy (col.gameObject);
			}
		}

		if (col.gameObject.tag == "AbraFight2") {
			GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().abraCounter2++;
			if (GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().abraCounter2 < 2) {
				Time.timeScale = 0;
				PlayerPrefs.SetString ("LastLevel", SceneManager.GetActiveScene ().name);
				SceneManager.LoadSceneAsync ("FightScreenAbra2",LoadSceneMode.Additive);
				canvasT.ToggleCanvas();
			} else {
				Destroy (col.gameObject);
			}
		}

		if (col.gameObject.tag == "EnemyFight1") {
			GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().enemyCounter1++;
			if (GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().enemyCounter1 < 2) {
				Time.timeScale = 0;
				PlayerPrefs.SetString ("LastLevel", SceneManager.GetActiveScene ().name);
				SceneManager.LoadSceneAsync ("FightScreenEnemy",LoadSceneMode.Additive);
				canvasT.ToggleCanvas();
			} else {
				Destroy (col.gameObject);
				GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().enemyCounter1=0;
			}
		}

		if (col.gameObject.tag == "EnemyFight2") {
			GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().enemyCounter2++;
			if (GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().enemyCounter2 < 2) {
				Time.timeScale = 0;
				PlayerPrefs.SetString ("LastLevel", SceneManager.GetActiveScene ().name);
				SceneManager.LoadSceneAsync ("FightScreenEnemy2",LoadSceneMode.Additive);
				canvasT.ToggleCanvas();
			} else {
				Destroy (col.gameObject);
				GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().enemyCounter2=0;
			}
		}

		if (col.gameObject.tag == "JeromeFight") {
			//GameDataController.SavePosition ();
			Debug.Log (GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().jeromeCounter);
			GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().jeromeCounter++;
			Debug.Log (GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().jeromeCounter);
			if (GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().jeromeCounter < 2) {
				Time.timeScale = 0;
				PlayerPrefs.SetString ("LastLevel", SceneManager.GetActiveScene ().name);
				SceneManager.LoadSceneAsync ("FightScreenJerome",LoadSceneMode.Additive);
				canvasT.ToggleCanvas();
			} else {
				Destroy (col.gameObject);
			}
		}
				
		if (col.gameObject.tag == "Potion") {
			Inventory.current.AddItem (col.gameObject.GetComponent<Item> ());
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag == "BridgeKeyItem1") {
			bridgeDoor1 = true;
			Inventory.current.AddItem (col.gameObject.GetComponent<Item> ());
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "BridgeKeyItem2") {
			bridgeDoor2 = true;
			Inventory.current.AddItem (col.gameObject.GetComponent<Item> ());
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "KeyItem") {
			door1 = true;
			Inventory.current.AddItem (col.gameObject.GetComponent<Item> ());
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "Item") {
			Inventory.current.AddItem (col.gameObject.GetComponent<Item> ());
			Destroy (col.gameObject);
		}
	}
	/// <summary>
	/// Instantiates ESC button to work as a Pause Button
	/// </summary>
	void Buttons ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("PauseMenu");
		}
	}
}


