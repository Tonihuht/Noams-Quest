﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyFight2 : MonoBehaviour {

	//create character and create random variable for accuracy
	public Character Noam;
	public Character Enemy2 = new Enemy2();
	private int randomAccuracy;
	private int randomAction = 0;
	public GameDataController controller;
	public ButtonController bAttack;
	public ButtonController bDodge;
	public ButtonController bBlock;
	public CanvasToggler canvasT;


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
		Noam = GameObject.Find ("GameController").GetComponent<GameController> ().noam;
		canvasT = GameObject.Find ("CanvasButton").GetComponent<CanvasToggler> ();
		bAttack = GameObject.Find ("AttackButton").GetComponent<ButtonController> ();
		bDodge = GameObject.Find ("DodgeButton").GetComponent<ButtonController> ();
		bBlock = GameObject.Find ("BlockButton").GetComponent<ButtonController> ();
	}

	void Update () {

		switch (currentState) {
		//Players move
		case (FightStates.PLAYERCHOICE):
			//Attack move happens if UpArrow is pushed
			if (Input.GetKeyDown (KeyCode.UpArrow) || bAttack.GetButtonPressed()) {
				//Generate random variable for testing accuracy
				randomAccuracy = Random.Range (1, 101);
				//Compare random variable to Noams accuracy to see if attack hits
				if (randomAccuracy > 0 && randomAccuracy <= Noam.Accuracy) {
					//Does Damage(dmg) to enemy
					Enemy2.Hp = Enemy2.Hp - Noam.Dmg;
				} 
				//Reset Noam's Damage(dmg) and accuracy statistics
				Noam.Dmg = 25;
				Noam.Accuracy = 100;
				//Checks if the enemy is alive 
				if (Enemy2.Hp > 0) {
					// If yes, changes state to ENEMYSCHOICE
					currentState = FightStates.ENEMYCHOICE;
					//If no, changes state to WIN
				} else {
					currentState = FightStates.WIN;
				}
			}
			// if RightArrow key is pushed player performs a block action
			if (Input.GetKeyDown (KeyCode.RightArrow) ||bBlock.GetButtonPressed()) {
				//Block action decreases enemys damage (dmg) statistic
				Enemy2.Dmg = Enemy2.Dmg - Noam.Block;
				//switches to Enemys turn and resets Noams Damage(dmg) and accuracy to original value
				currentState = FightStates.ENEMYCHOICE;
				Noam.Dmg = 25;
				Noam.Accuracy = 100;
			}
			// if LeftArrow key is pushed player performs a dodge action
			if (Input.GetKeyDown (KeyCode.LeftArrow) || bDodge.GetButtonPressed()) {
				//Dodge action decreases enemys accuracy statistic
				Enemy2.Accuracy = Enemy2.Accuracy - Noam.Dodge;
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
				//Compare random variable to Enemy2 accuracy to see if attack hits
				if (randomAccuracy > 0 && randomAccuracy <= Enemy2.Accuracy) {
					//Does Damage(dmg) to enemy
					Noam.Hp = Noam.Hp - Enemy2.Dmg;
				}
				//resets Enemy2 Damage(dmg) and accuracy to original value
				Enemy2.Dmg = 30;
				Enemy2.Accuracy = 70;
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
				Noam.Dmg = Noam.Dmg - Enemy2.Block;
				//changes fightstate to PLAYERCHOICE
				//resets Enemy2 Dmg and accuracy statistics to original values
				currentState = FightStates.PLAYERCHOICE;
				Enemy2.Dmg = Enemy2.Dmg + 10;
				Enemy2.Accuracy = Enemy2.Accuracy + 10;
			}
			//Dodge move happens if randomAction variable shuffles 5
			if (randomAction == 5) {
				//Dodge decreasses Noams accuracy
				Noam.Accuracy = Noam.Accuracy - Enemy2.Dodge;
				//changes fightstate to PLAYERCHOICE
				//resets Enemy2 Dmg and accuracy statistics to original values
				currentState = FightStates.PLAYERCHOICE;
				Enemy2.Dmg = Enemy2.Dmg + 10;
				Enemy2.Accuracy = Enemy2.Accuracy + 10;
			}

			/*
			Debug.Log (Noam.Name);
			Debug.Log (Noam.Description);
			Debug.Log (Noam.Hp);
			Debug.Log (Noam.Dmg);
			Debug.Log (Noam.Block);
			Debug.Log (Noam.Dodge);
			Debug.Log (Noam.Accuracy);

			Debug.Log (Enemy2.Name);
			Debug.Log (Enemy2.Description);
			Debug.Log (Enemy2.Hp);
			Debug.Log (Enemy2.Dmg);
			Debug.Log (Enemy2.Block);
			Debug.Log (Enemy2.Dodge);
			Debug.Log (Enemy2.Accuracy);
			*/							

			break;

		case (FightStates.WIN):
			Debug.Log ("WIN!");
			//you won !
			GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().enemyCounter2++;
			SceneManager.UnloadSceneAsync ("FightScreenEnemy2");
			Time.timeScale = 1;
			canvasT.ToggleCanvas();
			break;	

		case (FightStates.LOSE):
			Debug.Log ("LOSE");
			//you lost
			//Decreases enemyCounter2 by 1 so you have to fight him again
			GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().enemyCounter2=0;
			//loads first map
			SceneManager.UnloadSceneAsync ("FightScreenEnemy2");
			SceneManager.LoadScene (PlayerPrefs.GetString ("LastLevel"));
			Time.timeScale = 1;
			Noam.Hp = 100;
			Debug.Log (Noam.Hp);
			break;	

		}

	}
	/*private void PlayerHpCounter() {
			print (Noam.Hp);
	}	
		private void EnemyHpCounter () {
			print (Enemy2.Hp);
	}*/

}



