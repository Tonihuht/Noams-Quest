using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTester : MonoBehaviour {

	private Character Noam = new Noam();
	private Character Enemy1 = new Enemy1();


	void Start () {
		
	}
	

	void Update () {
		
	}

	void OnGUI(){

		GUILayout.Label (Noam.Name);
		GUILayout.Label (Noam.Description);
		GUILayout.Label (Noam.Hp.ToString());
		GUILayout.Label (Noam.Dmg.ToString());
		GUILayout.Label (Noam.Block.ToString());
		GUILayout.Label (Noam.Dodge.ToString());

		GUILayout.Label (Enemy1.Name);
		GUILayout.Label (Enemy1.Description);
		GUILayout.Label (Enemy1.Hp.ToString());
		GUILayout.Label (Enemy1.Dmg.ToString());
		GUILayout.Label (Enemy1.Block.ToString());
		GUILayout.Label (Enemy1.Dodge.ToString());

	}
}
