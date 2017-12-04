using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitchLoad : MonoBehaviour {
	
	public AudioClip newTrack;
	public MusicManager theMM;

	// Use this for initialization
	void Start () {
		theMM = FindObjectOfType<MusicManager>();
		if (newTrack != null) {
			theMM.ChangeBGM (newTrack);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
