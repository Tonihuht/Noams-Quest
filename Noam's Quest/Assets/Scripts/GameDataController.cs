using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataController : MonoBehaviour
{
	public int jeromeCounter = 0;
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


}

