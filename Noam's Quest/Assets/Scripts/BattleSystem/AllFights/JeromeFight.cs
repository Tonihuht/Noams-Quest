using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JeromeFight : MonoBehaviour
{
		
	//create character and create random variable for accuracy
	public Character Noam;
	public Character Jerome = new Jerome ();
	private int randomAccuracy;
	private int randomAction = 0;
	public GameDataController controller;
		
		
	// Setup all different states that fight can be in
	public enum FightStates
	{
		PLAYERCHOICE,
		ENEMYCHOICE,
		LOSE,
		WIN,
	}

	private FightStates currentState;



	void Start ()
	{
		currentState = FightStates.PLAYERCHOICE;
		Noam = GameObject.Find ("GameController").GetComponent<GameController> ().noam;
	}

	void Update ()
	{
		
		switch (currentState) {
		//Players move
		case (FightStates.PLAYERCHOICE):
			//Attack move happens if UpArrow is pushed
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				//Generate random variable for testing accuracy
				randomAccuracy = Random.Range (1, 101);
				//Compare random variable to Noams accuracy to see if attack hits
				if (randomAccuracy > 0 && randomAccuracy <= Noam.Accuracy) {
					//Does Damage(dmg) to enemy
					Jerome.Hp = Jerome.Hp - Noam.Dmg;
				} 
				//Reset Noam's Damage(dmg) and accuracy statistics
				Noam.Dmg = 25;
				Noam.Accuracy = 100;
				//Checks if the enemy is alive 
				if (Jerome.Hp > 0) {
					// If yes, changes state to ENEMYSCHOICE
					currentState = FightStates.ENEMYCHOICE;
					//If no, changes state to WIN
				} else {
					currentState = FightStates.WIN;
				}
			}
			// if RightArrow key is pushed player performs a block action
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				//Block action decreases enemys damage (dmg) statistic
				Jerome.Dmg = Jerome.Dmg - Noam.Block;
				//switches to Enemys turn and resets Noams Damage(dmg) and accuracy to original value
				currentState = FightStates.ENEMYCHOICE;
				Noam.Dmg = 25;
				Noam.Accuracy = 100;
			}
			// if LeftArrow key is pushed player performs a dodge action
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				//Dodge action decreases enemys accuracy statistic
				Jerome.Accuracy = Jerome.Accuracy - Noam.Dodge;
				//switches to Enemys turn and resets Noams Damage(dmg) and accuracy to original value
				currentState = FightStates.ENEMYCHOICE;
				Noam.Dmg = 25;
				Noam.Accuracy = 100;
			}

			//inventory was supposed to come, but was left out eventually
			// if DownArrow key is pushed player performs a inventory action
			/*if (Input.GetKeyDown (KeyCode.DownArrow)) {
				//SceneManager.LoadScene ("InventoryPrototype1");
				//switches to Enemys turn and resets Noams Damage(dmg) and accuracy to original value
				currentState = FightStates.ENEMYCHOICE;
				Noam.Dmg = 25;
				Noam.Accuracy = 100;
			}*/

			break;

		case (FightStates.ENEMYCHOICE):
			//random action is shuffled for enemy to use 1-3 attack, 4 block and 5 to dodge
			randomAction = Random.Range (1, 6);
			//Attack move happens if randomAction variable shuffles 1-3
			if (randomAction < 4) {
				
				//Generate random variable between 1-100 for testing accuracy
				randomAccuracy = Random.Range (1, 101);
				//Compare random variable to Jeromes accuracy to see if attack hits
				if (randomAccuracy > 0 && randomAccuracy <= Jerome.Accuracy) {
					//Does Damage(dmg) to enemy
					Noam.Hp = Noam.Hp - Jerome.Dmg;
				}
				//resets Jeromes Damage(dmg) and accuracy to original value
				Jerome.Dmg = 25;
				Jerome.Accuracy = 100;
				//Checks if the player is alive
				if (Noam.Hp > 0) {
					// If yes, changes state to PLAYERCHOISE
					currentState = FightStates.PLAYERCHOICE;
					//If no, changes state to LOSE
				} else {
					currentState = FightStates.LOSE;
				}
			}
			//Block move happens if randomAction variable shuffles 4
			if (randomAction == 4) {
				//Block decreases Noam's Dmg
				Noam.Dmg = Noam.Dmg - Jerome.Block;
				//changes fightstate to PLAYERCHOICE
				//resets Jeromes Dmg and accuracy statistics to original values
				currentState = FightStates.PLAYERCHOICE;
				Jerome.Dmg = 25;
				Jerome.Accuracy = 100;
			}
			//Dodge move happens if randomAction variable shuffles 5
			if (randomAction == 5) {
				//Dodge decreasses Noams accuracy
				Noam.Accuracy = Noam.Accuracy - Jerome.Dodge;
				//changes fightstate to PLAYERCHOICE
				//resets Jeromes Dmg and accuracy statistics to original values
				currentState = FightStates.PLAYERCHOICE;
				Jerome.Dmg = 25;
				Jerome.Accuracy = 100;
			}
			Debug.Log ("Your health: " + Noam.Hp);
			/*
			Debug.Log (Noam.Name);
			Debug.Log (Noam.Description);
			Debug.Log (Noam.Hp);
			Debug.Log (Noam.Dmg);
			Debug.Log (Noam.Block);
			Debug.Log (Noam.Dodge);
			Debug.Log (Noam.Accuracy);

			Debug.Log (Jerome.Name);
			Debug.Log (Jerome.Description);
			Debug.Log (Jerome.Hp);
			Debug.Log (Jerome.Dmg);
			Debug.Log (Jerome.Block);
			Debug.Log (Jerome.Dodge);
			Debug.Log (Jerome.Accuracy);
			*/							

			break;

		case (FightStates.WIN):
			Debug.Log ("WIN!");
			//you won !
			//Loads last map played before fight screen
			SceneManager.UnloadSceneAsync ("FightScreenJerome");
			//SceneManager.LoadScene (PlayerPrefs.GetString ("LastLevel"));
			Time.timeScale = 1;
			break;	

		case (FightStates.LOSE):
			Debug.Log ("LOSE");
			//you lost
			//Decreases jeromeCounter by 1 so you have to fight him again
			GameObject.Find ("jeromeCounter").GetComponent<GameDataController> ().jeromeCounter--;
			//loads first map
			SceneManager.LoadScene ("Tutorial");
			Time.timeScale = 1;
			break;	

		}

	}
	/*private void PlayerHpCounter() {
			print (Noam.Hp);
	}	
		private void EnemyHpCounter () {
			print (Jerome.Hp);
	}*/

}

	

