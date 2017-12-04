using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerCheck : MonoBehaviour {

	public GameObject musicMan;

	// Use this for initialization
	void Start () {
		if (FindObjectOfType<MusicManager> ()) 
			return;
		else 
			Instantiate (musicMan, transform.position, transform.rotation);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
