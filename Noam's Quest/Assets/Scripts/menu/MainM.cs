using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainM : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayButton()
    {
		SceneManager.LoadScene ("Tutorial");
    }

	public void LoadyButton()
	{
		Debug.Log("Loadingding");
	}


    public void ExitButton()
    {
		Debug.Log ("Application quitted");
        Application.Quit();
    }

}
