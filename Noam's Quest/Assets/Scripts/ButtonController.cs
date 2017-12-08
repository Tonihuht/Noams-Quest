using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public GameObject player;
	public float PlayerX;
	public float PlayerY;
	public bool buttonPressed;
	public float moveSpeed = 1f;

	public void Start ()
	{
		//Finds player
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	public bool GetButtonPressed ()
	{
		return this.buttonPressed;
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		//Debug.Log (eventData);
		this.buttonPressed = true;
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		//Debug.Log (eventData);
		this.buttonPressed = false;
	}

	/*public void ButtonLeft ()
	{
		movingX = -1;
		Input.GetAxis ("Horizontal");
	}

	public void ButtonRight ()
	{
		movingX = 1;
		Input.GetAxis ("Horizontal");
		//player.transform.Translate (0.5f, 0, 0);
	}

	public void ButtonUp ()
	{
		movingY = 1;
		player.transform.Translate (0, 0.5f, 0);
	}

	public void ButtonDown ()
	{
		movingY = -1;
		player.transform.Translate (0, -0.5f, 0);
	}

	public void ButtonZ ()
	{
		PlayerPrefs.SetString ("LastLevel", SceneManager.GetActiveScene ().name);
		PlayerPrefs.SetFloat ("PlayerX", transform.position.x);
		PlayerPrefs.SetFloat ("PlayerY", transform.position.y);
		PlayerPrefs.Save ();
		print (PlayerPrefs.GetString ("LastLevel"));
		SceneManager.LoadScene ("PauseMenu");
	}*/
}
