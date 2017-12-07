using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyFight : MonoBehaviour {

	//create character and create random variable for accuracy
	public Character Noam;
	public Character Enemy1 = new Enemy1();
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
		Debug.Log (GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().enemyCounter2);
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
					Debug.Log("Hit");
					Enemy1.Hp = Enemy1.Hp - Noam.Dmg;
				} 
				//Reset Noam's Damage(dmg) and accuracy statistics
				Noam.Dmg = 25;
				Noam.Accuracy = 100;
				//Checks if the enemy is alive 
				if (Enemy1.Hp > 0) {
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
				Enemy1.Dmg = Enemy1.Dmg - Noam.Block;
				//switches to Enemys turn and resets Noams Damage(dmg) and accuracy to original value
				currentState = FightStates.ENEMYCHOICE;
				Noam.Dmg = 25;
				Noam.Accuracy = 100;
			}
			// if LeftArrow key is pushed player performs a dodge action
			if (Input.GetKeyDown (KeyCode.LeftArrow) || bDodge.GetButtonPressed()) {
				//Dodge action decreases enemys accuracy statistic
				Enemy1.Accuracy = Enemy1.Accuracy - Noam.Dodge;
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
				//Compare random variable to Enemy1 accuracy to see if attack hits
				if (randomAccuracy > 0 && randomAccuracy <= Enemy1.Accuracy) {
					//Does Damage(dmg) to enemy
					Noam.Hp = Noam.Hp - Enemy1.Dmg;
				}
				//resets Enemy1 Damage(dmg) and accuracy to original value
				Enemy1.Dmg = 20;
				Enemy1.Accuracy = 90;
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
				Noam.Dmg = Noam.Dmg - Enemy1.Block;
				//changes fightstate to PLAYERCHOICE
				//resets Enemy1 Dmg and accuracy statistics to original values
				currentState = FightStates.PLAYERCHOICE;
				Enemy1.Dmg = 20;
				Enemy1.Accuracy = 90;
			}
			//Dodge move happens if randomAction variable shuffles 5
			if (randomAction == 5) {
				//Dodge decreasses Noams accuracy
				Noam.Accuracy = Noam.Accuracy - Enemy1.Dodge;
				//changes fightstate to PLAYERCHOICE
				//resets Enemy1 Dmg and accuracy statistics to original values
				currentState = FightStates.PLAYERCHOICE;
				Enemy1.Dmg = 20;
				Enemy1.Accuracy = 90;
			}

			/*
			Debug.Log (Noam.Name);
			Debug.Log (Noam.Description);
			Debug.Log (Noam.Hp);
			Debug.Log (Noam.Dmg);
			Debug.Log (Noam.Block);
			Debug.Log (Noam.Dodge);
			Debug.Log (Noam.Accuracy);

			Debug.Log (Enemy1.Name);
			Debug.Log (Enemy1.Description);
			Debug.Log (Enemy1.Hp);
			Debug.Log (Enemy1.Dmg);
			Debug.Log (Enemy1.Block);
			Debug.Log (Enemy1.Dodge);
			Debug.Log (Enemy1.Accuracy);
			*/							

			break;

		case (FightStates.WIN):
			//you won !
			GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().enemyCounter1++;
			SceneManager.UnloadSceneAsync ("FightScreenEnemy");
			Time.timeScale = 1;
			break;	

		case (FightStates.LOSE):
			//you lost
			//Decreases enemyCounter1 by 1 so you have to fight him again
			GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().enemyCounter1=0;
			//loads first mapDebug.Log (GameObject.FindGameObjectWithTag ("InventoryCanvas").GetComponent<GameDataController> ().enemyCounter2);
			SceneManager.UnloadSceneAsync ("FightScreenEnemy");
			SceneManager.LoadScene (PlayerPrefs.GetString ("LastLevel"));
			Time.timeScale = 1;
			break;	

		}

	}
	/*private void PlayerHpCounter() {
			print (Noam.Hp);
	}	
		private void EnemyHpCounter () {
			print (Enemy1.Hp);
	}*/

}



