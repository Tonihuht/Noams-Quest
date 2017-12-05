using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDataController : MonoBehaviour
{	
	
	public Text hpText;
	public int jeromeCounter = 0;
	public int crollCounter1 = 0;
	public int crollCounter2 = 0;
	public int abraCounter1 = 0;
	public int abraCounter2 = 0;
	public int enemyCounter1 = 0;

	/*public static GameDataController Instance;

	void Awake ()
	{
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		} else if (Instance != this) {
			Destroy (gameObject);
		}
	}*/


	void Start ()
	{	
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	/*public void LoadPosition () {

		transform.position = new Vector3(PlayerPrefs.GetFloat ("x"), PlayerPrefs.GetFloat ("y"), PlayerPrefs.GetFloat ("z"));
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		SavePosition ();
	}

	public void SavePosition(){

		PlayerPrefs.SetFloat ("x", transform.position.x);
		PlayerPrefs.SetFloat ("y", transform.position.y);
		PlayerPrefs.SetFloat ("z", transform.position.z);

	}*/

}

