using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnBasedCombat : MonoBehaviour {
		
		//create character and create random variable for accuracy
		private Character Noam = new Noam();
		private Character Enemy1 = new Enemy1();
		private int randomAccuracy;
		private int randomAction;
		
	// Setup all different states that fight can be in
public enum FightStates{
		PLAYERCHOICE,
		ENEMYCHOICE,
		LOSE,
		WIN,
	}

	private FightStates currentState;


	void Start () {
		currentState = FightStates.PLAYERCHOICE;
	}

	void Update () {
		switch (currentState) {
		//Players move
		case (FightStates.PLAYERCHOICE):
		//Attack move happens if UpArrow is pushed
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				Debug.Log ("Attack");
				//Generate random variable for testing accuracy
				randomAccuracy = Random.Range (1, 101);
				//Compare random variable to Noams accuracy to see if attack hits
				if (randomAccuracy > 0 && randomAccuracy <= Noam.Accuracy) {
					Debug.Log("HIT");
					//Does Dmg to enemy
					Enemy1.Hp = Enemy1.Hp - Noam.Dmg;
				}
				//Checks if the enemy is dead
				if (Enemy1.Hp <= 0) {
					// If yes, changes state to WIN
					Debug.Log ("WIN");
					currentState = FightStates.WIN;
					//If no, changes state to ENEMYCHOICE
				} else
					Debug.Log ("ENEMYCHOICE");
				currentState = FightStates.ENEMYCHOICE;
			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				Debug.Log ("Block");
				Enemy1.Dmg = Enemy1.Dmg - Noam.Block;
				currentState = FightStates.ENEMYCHOICE;
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				Debug.Log ("Dodge");
				Enemy1.Accuracy = Enemy1.Accuracy - Noam.Dodge;
				currentState = FightStates.ENEMYCHOICE;
			}
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				Debug.Log ("Inventory");
			}
			break;

		case (FightStates.ENEMYCHOICE):
			Debug.Log ("resetPlayerStatss");
			resetPlayerStats();

			break;	

		case (FightStates.WIN):
			break;	

		case (FightStates.LOSE):
			break;	

		}

		}
	// Resetting enemys Dmg and accuracy stats
	private void resetEnemyStats (){
		Enemy1.Dmg = Enemy1.Dmg;
		Enemy1.Accuracy = Enemy1.Accuracy;
	}
	// Resetting players Dmg and accuracy stats
	private void resetPlayerStats (){
		Noam.Dmg = Noam.Dmg;
		Noam.Accuracy = Noam.Accuracy;
	}

		
	}
	

