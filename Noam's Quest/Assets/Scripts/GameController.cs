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
	private ButtonController zButton;
	private GameObject player;
	public float speed = 0.01f;


	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		bLeft = GameObject.Find ("LeftArrow").GetComponent<ButtonController> ();
		bRight = GameObject.Find ("RightArrow").GetComponent<ButtonController> ();
		bUp = GameObject.Find ("UpArrow").GetComponent<ButtonController> ();
		bDown = GameObject.Find ("DownArrow").GetComponent<ButtonController> ();
		zButton = GameObject.Find ("ZButton").GetComponent<ButtonController> ();
	}

	void Update ()
	{
		/*if (zButton.GetButtonPressed ()) {
			PlayerPrefs.SetFloat ("PlayerX", player.transform.position.x);
			PlayerPrefs.SetFloat ("PlayerY", player.transform.position.y);
			PlayerPrefs.SetString ("TutorialOut", SceneManager.GetActiveScene ().name);
			PlayerPrefs.Save ();
			print (PlayerPrefs.GetString ("TutorialOut"));
			SceneManager.LoadScene ("2");
		}
		/*if (bLeft.GetButtonPressed ()) {
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
			SceneManager.LoadScene ("2");
		}*/
	
	}
}