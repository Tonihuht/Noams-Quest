using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void ResumeButton ()
	{
		SceneManager.LoadScene (PlayerPrefs.GetString ("LastLevel"));
	}

	public void MainMenuB ()
	{
		SceneManager.LoadScene ("MainMenu");
	}

	public void SaveButton ()
	{
		
	}

	public void LoadButton ()
	{
		SceneManager.LoadScene (PlayerPrefs.GetString ("LastLevel"));
	}

	public void ExitButton ()
	{
		Debug.Log ("Quit");
		Application.Quit ();
	}
}
