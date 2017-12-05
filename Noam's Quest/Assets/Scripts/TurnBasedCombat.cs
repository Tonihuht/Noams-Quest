using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnBasedCombat : MonoBehaviour {
		
		//create character and create random variable for accuracy
		public Character Noam = new Noam();
		public Character Enemy1 = new Enemy1();
		private int randomAccuracy;
		private int randomAction = 0;
		public GameDataController controller;
		
		
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
			//reset Players stats
			//Debug.Log ("resetPlayerStats");
			//Attack move happens if UpArrow is pushed
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				//Debug.Log ("AttackMoveSelected");
				//Generate random variable for testing accuracy
				randomAccuracy = Random.Range (1, 101);
				//Debug.Log (randomAccuracy);
				//Compare random variable to Noams accuracy to see if attack hits
				if (randomAccuracy > 0 && randomAccuracy <= Noam.Accuracy) {
					//Debug.Log ("HIT");
					//Does Dmg to enemy
					Enemy1.Hp = Enemy1.Hp - Noam.Dmg;
				} 
				Noam.Dmg = 25;
				Noam.Accuracy = 100;
				//Debug.Log (Noam.Dmg);
				//Debug.Log (Noam.Accuracy);
				//Checks if the enemy is dead
				if (Enemy1.Hp > 0) {
					// If yes, changes state to ENEMYSCHOICE
					//Debug.Log ("Enemyturn");
					currentState = FightStates.ENEMYCHOICE;
					//If no, changes state to WIN
				} else {
					currentState = FightStates.WIN;
				}
			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				//Debug.Log ("Block");
				Enemy1.Dmg = Enemy1.Dmg - Noam.Block;
				currentState = FightStates.ENEMYCHOICE;
				Noam.Dmg = 25;
				Noam.Accuracy = 100;
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				//Debug.Log ("Dodge");
				Enemy1.Accuracy = Enemy1.Accuracy - Noam.Dodge;
				currentState = FightStates.ENEMYCHOICE;
				Noam.Dmg = 25;
				Noam.Accuracy = 100;
			}
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				//Debug.Log ("Inventory");
				//SceneManager.LoadScene ("InventoryPrototype1");
				currentState = FightStates.ENEMYCHOICE;
				Noam.Dmg = 25;
				Noam.Accuracy = 100;
			}
			break;

		case (FightStates.ENEMYCHOICE):
			//reset Enemys stats
			//Debug.Log ("resetEnemyStats");
			randomAction = Random.Range (1, 4);
			//Debug.Log (randomAction);
			//Attack move happens if randomAction variable shuffles 1
			if (randomAction == 1) {
				
				//Generate random variable for testing accuracy
				randomAccuracy = Random.Range (1, 101);
				//Debug.Log (randomAccuracy);
				//Compare random variable to Noams accuracy to see if attack hits
				if (randomAccuracy > 0 && randomAccuracy <= Enemy1.Accuracy) {
					//Does Dmg to enemy
					Noam.Hp = Noam.Hp - Enemy1.Dmg;
					Debug.Log (Noam.Hp);
					Enemy1.Dmg = 10;
					Enemy1.Accuracy = 90;
				}
				//Checks if the player is dead
				if (Noam.Hp > 0) {
					// If yes, changes state to LOSE
					currentState = FightStates.PLAYERCHOICE;
					//If no, changes state to PLAYERCHOICE
				} else {
					//Change state to PLAYERCHOICE
					currentState = FightStates.LOSE;
				}
			}
			//Block move happens if randomAction variable shuffles 2
			if (randomAction == 2) {
				Noam.Dmg = Noam.Dmg - Enemy1.Block;
				currentState = FightStates.PLAYERCHOICE;
				Enemy1.Dmg = 10;
				Enemy1.Accuracy = 90;
			}
			//Dodge move happens if randomAction variable shuffles 3
			if (randomAction == 3) {
				Noam.Accuracy = Noam.Accuracy - Enemy1.Dodge;
				currentState = FightStates.PLAYERCHOICE;
				Enemy1.Dmg = 10;
				Enemy1.Accuracy = 90;
			}

			break;

		case (FightStates.WIN):
			//SceneManager.LoadScene ( PlayerPrefs.GetInt("TutorialAfterFight") );
			SceneManager.LoadScene (PlayerPrefs.GetString ("LastLevel"));
			//GameDataController.LoadPosition ();
			Debug.Log (Noam.Hp);
			break;	

		case (FightStates.LOSE):
			
			GameObject.Find ("jeromeCounter").GetComponent<GameDataController> ().jeromeCounter--;
			SceneManager.LoadScene ("Tutorial");
			Debug.Log (Noam.Hp);
			break;	

		}

	}
		private void PlayerHpCounter() {
			print (Noam.Hp);
	}	
		private void EnemyHpCounter () {
			print (Enemy1.Hp);
	}

}

	

