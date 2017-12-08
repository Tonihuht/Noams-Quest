using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	//Instantiates the players stats
	public Character noam;

	void Start ()
	{	
		//Calls the instance
		DontDestroyOnLoad (gameObject);
		noam = new Noam ();
		/*noamsHP = noam.Hp;
		playersHp.text = "Noams hp: " + noamsHP;
		pickedPotions.text = "Total potions -> " + pickPotion;
		pickPotion = 0;*/
	}

	void Update ()
	{
		//playersHp.text = "Noams hp: " + noamsHP;
		//playersHp.text = "Noams hp: " + noamsHP;
	}

	/*public int totalPotions (Collision2D col){
		if (col.gameObject.tag == "Potion") {
			pickPotion++;
			return pickPotion;
		} else { 
			return pickPotion;
		}
	}*/
}