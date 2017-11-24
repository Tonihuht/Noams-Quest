using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Fighter
	{
		public string name;
		public int hp;
		public int attack;

		public Fighter (string name, int hp, int attack)
		{
			this.name = name;
			this.hp = hp;
			this.attack = attack;
		}
	}
}

