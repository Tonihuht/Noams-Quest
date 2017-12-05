using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    GameObject Pausemenu;
    bool paused;

	// Use this for initialization
	void Start () {
        paused = false;
        Pausemenu = GameObject.Find("2");
		
	}
	
	// Update is called once per frame
	void Update () {
        /*if(Input.GetKeyDown(KeyCode.Escape))
        {
            paused = true;
        }
        if (paused == true)
        {
            Pausemenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if (paused == false)
        {
            Pausemenu.SetActive(false);
            Time.timeScale = 1;
        }*/
		
	}
    public void ResumeButton()
    {
		transform.position = new Vector2 (PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"));
		SceneManager.LoadScene ( PlayerPrefs.GetString("LastLevel") );

		paused = false;
    }
    public void MainMenuB()
    {
		SceneManager.LoadScene ("MainMenu");
    }
    public void SaveButton()
    {
        PlayerPrefs.SetInt("currentscenesave", Application.loadedLevel);
    }
    public void LoadButton()
    {
        Application.LoadLevel(PlayerPrefs.GetInt("currentscenesave"));
    }
    public void ExitButton()
    {
		Debug.Log ("Quit");
        Application.Quit();
    }
}
