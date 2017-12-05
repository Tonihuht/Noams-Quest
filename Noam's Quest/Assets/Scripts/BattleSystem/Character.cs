using System;
using System.Collections.Generic;
using UnityEngine;


public class Character
{
	// Name and description of character
	private string name;
	private string description;
	//Stats of character
	public int hp;
	private int dmg;
	private int block;
	private int dodge;
	private int accuracy;

	public string Name {
		get{ return name; }
		set{ name = value; }
	}

	public string Description {
		get{ return description; }
		set{ description = value; }
	}

	public int Hp {
		get{ return hp; }
		set{ hp = value; }
	}

	public int Dmg {
		get{ return dmg; }
		set{ dmg = value; }
	}

	public int Block {
		get{ return block; }
		set{ block = value; }
	}

	public int Dodge {
		get{ return dodge; }
		set{ dodge = value; }
	}

	public int Accuracy {
		get{ return accuracy; }
		set{ accuracy = value; }
	}

		
}


