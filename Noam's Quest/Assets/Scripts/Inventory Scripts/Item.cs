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
	// Use this for initialization
	public void Use ()
	{
		switch (type) {
		case ItemType.HEALTH:
			Debug.Log ("Used a health potion");
			break;
		case ItemType.KEY:
			Debug.Log ("Used a key");
			break;
		}
	}
}
