using UnityEngine;
using System.Collections;
using System;

namespace com.pedromr.games.shmup
{
	public class PlayerState : ScriptableObject
	{
		public int scrap;

		internal void addLoot(ILoot loot)
		{
			loot.AddToPlayerState(this);
		}
	}
}