using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
HEALTH,
	KEY}
;

public class Item : MonoBehaviour
{

	public ItemType type;
	public Sprite spriteNeutral;
	public Sprite spriteHighlighted;
	public int maxSize;
	public Character Noam;

	void Start () {
		Noam = GameObject.Find ("GameController").GetComponent<GameController> ().noam;
	}
	//When called defines the used items type
	public void Use ()
	{
		switch (type) {
		case ItemType.HEALTH:
			Debug.Log ("Used a health potion");
			Noam.Hp += 20;
			Debug.Log ("Your health: " + Noam.Hp);
			break;
		case ItemType.KEY:
			Debug.Log ("Used a key");
			break;
		}
	}
}
