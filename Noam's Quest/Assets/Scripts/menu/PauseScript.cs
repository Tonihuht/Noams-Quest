using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {

    GameObject Pausemenu;
    bool paused;

	// Use this for initialization
	void Start () {
        paused = false;
        Pausemenu = GameObject.Find("Pausemenu");
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
        if (paused)
        {
            Pausemenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            Pausemenu.SetActive(false);
            Time.timeScale = 1;
        }
		
	}
    public void ResumeButton()
    {
        paused = false;
    }
    public void MainMenuB()
    {
        Application.LoadLevel(1);
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
        Application.Quit();
    }
}
