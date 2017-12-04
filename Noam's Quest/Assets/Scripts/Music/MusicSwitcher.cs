using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour {

	public AudioClip newTrack;
	public MusicManager theMM;

	// Use this for initialization
	void Start () {
		//theMM = FindObjectOfType<MusicManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			if (newTrack != null) {
				theMM = FindObjectOfType<MusicManager>();
				theMM.ChangeBGM (newTrack);
			}
		}
	}
}
