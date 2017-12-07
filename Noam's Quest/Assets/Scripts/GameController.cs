using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public Character noam;
	//public Text playersHp;
	//public Text pickedPotions;
	//public int pickPotion;
	//public int noamsHP;
	/*private ButtonController bLeft;
	private ButtonController bRight;
	private ButtonController bUp;
	private ButtonController bDown;
	private ButtonController zButton;
	private GameObject player;
	public float speed = 0.01f;*/


	void Start ()
	{	
		
		DontDestroyOnLoad (gameObject);
		noam = new Noam ();
		/*noamsHP = noam.Hp;
		playersHp.text = "Noams hp: " + noamsHP;
		pickedPotions.text = "Total potions -> " + pickPotion;
		pickPotion = 0;
		player = GameObject.FindGameObjectWithTag ("Player");
		bLeft = GameObject.Find ("LeftArrow").GetComponent<ButtonController> ();
		bRight = GameObject.Find ("RightArrow").GetComponent<ButtonController> ();
		bUp = GameObject.Find ("UpArrow").GetComponent<ButtonController> ();
		bDown = GameObject.Find ("DownArrow").GetComponent<ButtonController> ();
		zButton = GameObject.Find ("ZButton").GetComponent<ButtonController> ();*/
	}

	void Update ()
	{
		//playersHp.text = "Noams hp: " + noamsHP;
		//playersHp.text = "Noams hp: " + noamsHP;
		/*if (zButton.GetButtonPressed ()) {
			PlayerPrefs.SetFloat ("PlayerX", player.transform.position.x);
			PlayerPrefs.SetFloat ("PlayerY", player.transform.position.y);
			PlayerPrefs.SetString ("TutorialOut", SceneManager.GetActiveScene ().name);
			PlayerPrefs.Save ();
			print (PlayerPrefs.GetString ("TutorialOut"));
			SceneManager.LoadScene ("PauseMenu");
		}
		if (bLeft.GetButtonPressed ()) {
			Debug.Log ("Moving left");
			player.transform.Translate(0.1f * speed, 0, 0);
		}
		if (bRight.GetButtonPressed ()) {
			//Debug.Log ("Moving right");
			player.transform.Translate(0.1f * speed, 0, 0);
		}
		if (bUp.GetButtonPressed ()) {
			//Debug.Log ("Moving left");
			player.transform.Translate(0, 0.1f * speed, 0);
		}
		if (bDown.GetButtonPressed ()) {
			//Debug.Log ("Moving left");
			player.transform.Translate(0, -0.1f * speed, 0);
		}
		if (zButton.GetButtonPressed ()) {
			SceneManager.LoadScene ("PauseMenu");
		}*/
	
	}
	/*public int totalPotions (Collision2D col){
		if (col.gameObject.tag == "Potion") {
			pickPotion++;
			return pickPotion;
		} else { 
			return pickPotion;
		}
	}*/
}