using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatSystem : MonoBehaviour {

	int enemyHp = 100;
	int playerHp = 100;
	int enemyDmg = 10;
	int playerDmg = 20;
	int playerIndex = 0;
	int enemyIndex = 0;




	public void Turns () {

		if (playerHp <= 0 || enemyHp <= 0)
		while (playerIndex <= enemyIndex) {
			
			enemyHp = enemyHp - playerDmg;

			playerIndex++;
		}
		playerHp = playerHp - enemyDmg;

		enemyIndex++;

	}

}
